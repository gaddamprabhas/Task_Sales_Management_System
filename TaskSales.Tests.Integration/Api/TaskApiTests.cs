// Week 9 - Day 6
// Integration Test: Task API basic flow

using Xunit;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
using System.Net;
using System.Net.Http.Json;

namespace TaskSales.Tests.Integration.Api
{
    public class TaskApiTests
        : IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly HttpClient _client;

        public TaskApiTests(WebApplicationFactory<Program> factory)
        {
            _client = factory.CreateClient();
        }

        [Fact]
        public async Task Get_Tasks_Should_Return_Response()
        {
            // Act
            var response = await _client.GetAsync("/api/tasks");

            // Assert
            response.StatusCode.Should().BeOneOf(
                HttpStatusCode.OK,
                HttpStatusCode.NoContent
            );
        }
    }
}