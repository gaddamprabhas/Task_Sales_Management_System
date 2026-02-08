// Week 9 Day 7 - Activity Logs API Controller

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using TaskSales.Infrastructure.Mongo;
using TaskSales.Infrastructure.MongoModels;

namespace TaskSales.Api.Controllers.Logs;

[ApiController]
[Route("api/logs")]

public class ActivityLogsController : ControllerBase
{
    private readonly MongoDbService _mongoService;

    public ActivityLogsController(MongoDbService mongoService)
    {
        _mongoService = mongoService;
    }

    // GET: api/logs
    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var logs = await _mongoService.ActivityLogs
            .Find(Builders<ActivityLog>.Filter.Empty)
            .SortByDescending(x => x.Timestamp)
            .ToListAsync();

        return Ok(logs);
    }
}
