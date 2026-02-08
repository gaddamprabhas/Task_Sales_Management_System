// Week 9 - Day 6
// Integration Test: SQL DbContext can be created

using Xunit;
using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Mvc.Testing;
using TaskSales.Infrastructure.Data;

namespace TaskSales.Tests.Integration.Infrastructure
{
    public class DatabaseConnectionTests
        : IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly IServiceProvider _services;

        public DatabaseConnectionTests(WebApplicationFactory<Program> factory)
        {
            _services = factory.Services;
        }

        [Fact]
        public void DbContext_Should_Be_Resolved()
        {
            using var scope = _services.CreateScope();
            var dbContext = scope.ServiceProvider.GetService<ApplicationDbContext>();

            dbContext.Should().NotBeNull();
        }
    }
}