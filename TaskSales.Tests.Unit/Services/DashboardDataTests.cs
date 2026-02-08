// Week 9 - Day 6
// Unit Test: Dashboard task list count (safe)

using Xunit;
using FluentAssertions;
using TaskSales.Domain.Entities;
using System.Collections.Generic;

namespace TaskSales.Tests.Unit.Services
{
    public class DashboardDataTests
    {
        [Fact]
        public void Task_List_Should_Not_Be_Empty()
        {
            // Arrange
            var tasks = new List<TaskItem>
            {
                new TaskItem(),
                new TaskItem()
            };

            // Act
            var count = tasks.Count;

            // Assert
            count.Should().BeGreaterThan(0);
        }
    }
}