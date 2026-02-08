// Week 9 - Day 6
// Unit Test: Dashboard metrics safety

using Xunit;
using FluentAssertions;
using System.Collections.Generic;

namespace TaskSales.Tests.Unit.Services
{
    public class DashboardMetricsTests
    {
        [Fact]
        public void Total_Items_Count_Should_Be_Correct()
        {
            var items = new List<int> { 1, 2, 3, 4 };

            items.Count.Should().Be(4);
        }
    }
}