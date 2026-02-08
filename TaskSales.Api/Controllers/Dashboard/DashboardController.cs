using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TaskSales.Application.DTOs;
using TaskSales.Infrastructure.Data;
using DomainTaskStatus = TaskSales.Domain.Enums.TaskStatus;

namespace TaskSales.Api.Controllers.Dashboard
{
    [ApiController]
    [Route("api/dashboard")]
    public class DashboardController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public DashboardController(ApplicationDbContext context)
        {
            _context = context;
        }

        // ✅ KPI
        [HttpGet("kpis")]
        public async Task<IActionResult> GetKpis()
        {
            var totalTasks = await _context.Tasks.CountAsync();

            var completedTasks = await _context.Tasks.CountAsync(
                t => t.Status == TaskSales.Domain.Enums.TaskStatus.Completed
            );

            var totalSales = await _context.Sales.SumAsync(s => s.TotalAmount);

            return Ok(new DashboardKpiDto
            {
                TotalTasks = totalTasks,
                CompletedTasks = completedTasks,
                TotalSales = totalSales
            });
        }

        // ✅ SALES TREND
        [HttpGet("sales-trend")]
        public async Task<IActionResult> GetSalesTrend()
        {
            var data = await _context.Sales
                .GroupBy(s => s.SaleDate.Date)
                .Select(g => new SalesTrendDto
                {
                    Date = g.Key,
                    Total = g.Sum(x => x.TotalAmount)
                })
                .OrderBy(x => x.Date)
                .ToListAsync();

            return Ok(data);
        }
    }
}
