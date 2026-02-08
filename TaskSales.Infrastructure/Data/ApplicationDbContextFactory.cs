using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;


namespace TaskSales.Infrastructure.Data
{
    public class ApplicationDbContextFactory
        : IDesignTimeDbContextFactory<ApplicationDbContext>
    {
        public ApplicationDbContext CreateDbContext(string[] args)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Path.Combine(
    Directory.GetCurrentDirectory(), "..", "TaskSales.Api"))

                .AddJsonFile("appsettings.json")
                .Build();

            var optionsBuilder =
                new DbContextOptionsBuilder<ApplicationDbContext>();

            optionsBuilder.UseSqlServer(
                configuration.GetConnectionString("SqlConnection"));

            return new ApplicationDbContext(optionsBuilder.Options);
        }
    }
}
