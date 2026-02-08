// Week 9 - Day 6
// Integration Test: Task list for DataGrid

using Xunit;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
using System.Net;

namespace TaskSales.Tests.Integration.Api
{
    public class TaskGridApiTests
        : IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly HttpClient _client;

        public TaskGridApiTests(WebApplicationFactory<Program> factory)
        {
            _client = factory.CreateClient();
        }

        [Fact]
        public async Task Task_List_Endpoint_Should_Return_Response()
        {
            var response = await _client.GetAsync("/api/tasks");

            response.StatusCode.Should().BeOneOf(
                HttpStatusCode.OK,
                HttpStatusCode.NoContent
            );
        }
    }
}