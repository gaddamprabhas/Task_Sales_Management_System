using Microsoft.EntityFrameworkCore;
using TaskSales.Application.DTOs;
using TaskSales.Application.Interfaces;
using TaskSales.Domain.Entities;
using TaskSales.Infrastructure.Data;

namespace TaskSales.Infrastructure.Services
{
    public class SaleService : ISaleService
    {
        private readonly ApplicationDbContext _context;

        public SaleService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<SaleDto>> GetAllAsync()
        {
            return await _context.Sales
                .AsNoTracking()
                .Select(s => new SaleDto
                {
                    Id = s.Id,
                    ProductName = s.ProductName,
                    Quantity = s.Quantity,
                    TotalAmount = s.TotalAmount,
                    EmployeeId = s.EmployeeId,
                    SaleDate = s.SaleDate
                })
                .ToListAsync();
        }

        public async Task AddAsync(SaleDto sale)
        {
            if (sale.EmployeeId == 0)
                throw new Exception("EmployeeId is required");

            var entity = new Sale
            {
                ProductName = sale.ProductName,
                Quantity = sale.Quantity,
                TotalAmount = sale.TotalAmount,
                EmployeeId = sale.EmployeeId,
                SaleDate = sale.SaleDate == default
                    ? DateTime.UtcNow
                    : sale.SaleDate
            };

            await _context.Sales.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<decimal> GetTotalSalesAsync()
        {
            return await _context.Sales.SumAsync(x => x.TotalAmount);
        }
    }
}
