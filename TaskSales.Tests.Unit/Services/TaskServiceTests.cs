using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// Week 9 - Day 6
// Unit Test: Task business logic

using Xunit;
using FluentAssertions;
using TaskSales.Domain.Entities;

public class TaskServiceTests
{
    [Fact]
    public void CreateTask_Should_Set_Title_Correctly()
    {
        // Arrange
        var task = new TaskItem
        {
            Title = "CEO Demo Task"
        };

        // Act
        var result = task.Title;

        // Assert
        result.Should().Be("CEO Demo Task");
    }
}