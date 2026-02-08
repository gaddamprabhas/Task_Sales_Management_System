// Week 9 - Day 6
// Integration Test: API boot & host startup test (safe)

using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using System.Threading.Tasks;
using Xunit;

namespace TaskSales.Tests.Integration.Api
{
    public class HealthApiTests
        : IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly WebApplicationFactory<Program> _factory;

        public HealthApiTests(WebApplicationFactory<Program> factory)
        {
            _factory = factory;
        }

        [Fact]
        public void Api_Should_Start_Without_Exception()
        {
            // Act
            var exception = Record.Exception(() =>
            {
                var client = _factory.CreateClient();
            });

            // Assert
            exception.Should().BeNull();
        }
    }
}