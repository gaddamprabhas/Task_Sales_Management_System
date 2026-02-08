// Week 9 Day 3 - Sales Report Service
using Microsoft.EntityFrameworkCore;
using TaskSales.Application.DTOs;
using TaskSales.Application.Interfaces;
using TaskSales.Infrastructure.Data;

namespace TaskSales.Infrastructure.Services
{
    public class SalesReportService : ISalesReportService
    {
        private readonly ApplicationDbContext _context;

        public SalesReportService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<SalesReportDto>> GetSalesByEmployeeAsync()
        {
            return await _context.Sales
                .Include(s => s.Employee)
                .Where(s => s.Employee != null)   // ✅ safety
                .GroupBy(s => s.Employee!.FullName)
                .Select(g => new SalesReportDto
                {
                    EmployeeName = g.Key,
                    TotalSales = g.Sum(x => x.TotalAmount)
                })
                .ToListAsync();
        }
    }
}
