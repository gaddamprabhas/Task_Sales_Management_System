// Week 9 - Day 6
// Unit Test: Task entity default values

using Xunit;
using FluentAssertions;
using TaskSales.Domain.Entities;

namespace TaskSales.Tests.Unit.Domain
{
    public class TaskDefaultsTests
    {
        [Fact]
        public void New_Task_Should_Not_Be_Null()
        {
            // Act
            var task = new TaskItem();

            // Assert
            task.Should().NotBeNull();
        }
    }
}