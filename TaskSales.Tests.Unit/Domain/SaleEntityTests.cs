// Week 9 - Day 6
// Unit Test: Employee entity type check

using Xunit;
using FluentAssertions;
using TaskSales.Domain.Entities;

namespace TaskSales.Tests.Unit.Domain
{
    public class EmployeeEntityTypeTests
    {
        [Fact]
        public void Employee_Should_Be_Of_Type_Employee()
        {
            var employee = new Employee();

            employee.Should().BeOfType<Employee>();
        }
    }
}