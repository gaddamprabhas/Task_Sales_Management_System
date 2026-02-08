// Week 9 - Day 6
// Unit Test: Employee entity instantiation (safe, property-agnostic)

using Xunit;
using FluentAssertions;
using TaskSales.Domain.Entities;

namespace TaskSales.Tests.Unit.Domain
{
    public class EmployeeEntityTests
    {
        [Fact]
        public void Employee_Object_Should_Be_Created()
        {
            // Act
            var employee = new Employee();

            // Assert
            employee.Should().NotBeNull();
        }
    }
}