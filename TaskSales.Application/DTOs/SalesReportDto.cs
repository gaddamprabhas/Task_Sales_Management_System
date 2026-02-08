using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace TaskSales.Application.DTOs
{
    
        public class SalesReportDto
        {
            public string EmployeeName { get; set; } = string.Empty;
            public decimal TotalSales { get; set; }
        }
    
}
