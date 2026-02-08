using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using TaskSales.Application.DTOs;

// Week 9 Day 3 - Sales Report Interface


namespace TaskSales.Application.Interfaces
{
    public interface ISalesReportService
    {
        Task<List<SalesReportDto>> GetSalesByEmployeeAsync();
    }
}

