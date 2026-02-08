using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using TaskSales.Application.DTOs;

namespace TaskSales.Application.Interfaces
{
    public interface ISaleService
    {
        Task<List<SaleDto>> GetAllAsync();
        Task AddAsync(SaleDto sale);
        Task<decimal> GetTotalSalesAsync();
    }
}
