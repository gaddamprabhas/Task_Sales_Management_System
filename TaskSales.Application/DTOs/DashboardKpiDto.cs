using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace TaskSales.Application.DTOs
{
    // Week 9 Day 5 - Dashboard KPI DTO
    
        public class DashboardKpiDto
        {
            public int TotalTasks { get; set; }
            public int CompletedTasks { get; set; }
            public int PendingTasks { get; set; }
            public decimal TotalSales { get; set; }
        }
    

}
