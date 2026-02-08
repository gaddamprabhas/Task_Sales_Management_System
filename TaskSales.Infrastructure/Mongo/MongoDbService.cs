using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TaskSales.Infrastructure.MongoModels;

namespace TaskSales.Infrastructure.Mongo
{
    public class MongoDbService
    {
        private readonly IMongoDatabase _database;

        public MongoDbService(string connectionString, string databaseName)
        {
            var client = new MongoClient(connectionString);
            _database = client.GetDatabase(databaseName);
        }

        public IMongoCollection<UserFeedback> UserFeedbacks =>
            _database.GetCollection<UserFeedback>("UserFeedbacks");

        public IMongoCollection<ActivityLog> ActivityLogs =>
            _database.GetCollection<ActivityLog>("ActivityLogs");
        //activity log
        public async Task LogAsync(string action)
        {
            var log = new ActivityLog
            {
                Action = action,
                Timestamp = DateTime.UtcNow
            };

            await ActivityLogs.InsertOneAsync(log);
        }
    }
}
