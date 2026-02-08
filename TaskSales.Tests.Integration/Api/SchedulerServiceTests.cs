// Week 9 - Day 6
// Integration Test: Scheduler service DI

using Xunit;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using TaskSales.Application.Interfaces;

namespace TaskSales.Tests.Integration.Infrastructure
{
    public class SchedulerServiceTests
        : IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly IServiceProvider _services;

        public SchedulerServiceTests(WebApplicationFactory<Program> factory)
        {
            _services = factory.Services;
        }

        [Fact]
        public void Scheduler_Service_Should_Be_Resolved()
        {
            using var scope = _services.CreateScope();
            var service = scope.ServiceProvider.GetService<ISchedulerService>();

            service.Should().NotBeNull();
        }
    }
}