using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


// Week 9 Day 5 - Sales Entity

namespace TaskSales.Domain.Entities
{
    // Week 9 Day 5 - Sales Entity
    public class Sale
    {
        public int Id { get; set; }

        public string ProductName { get; set; } = string.Empty;
        public int Quantity { get; set; }
        public decimal TotalAmount { get; set; }

        public DateTime SaleDate { get; set; }

        // 🔑 FK
        public int EmployeeId { get; set; }

        // Navigation
        public Employee Employee { get; set; } = null!;
    }
}
