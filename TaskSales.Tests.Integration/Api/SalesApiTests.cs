// Week 9 - Day 6
// Integration Test: Sales API availability

using Xunit;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
using System.Net;

namespace TaskSales.Tests.Integration.Api
{
    public class SalesApiTests
        : IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly HttpClient _client;

        public SalesApiTests(WebApplicationFactory<Program> factory)
        {
            _client = factory.CreateClient();
        }

        [Fact]
        public async Task Sales_Endpoint_Should_Be_Accessible()
        {
            var response = await _client.GetAsync("/api/sales");

            response.StatusCode.Should().BeOneOf(
                HttpStatusCode.OK,
                HttpStatusCode.NoContent,
                HttpStatusCode.Unauthorized
            );
        }
    }
}