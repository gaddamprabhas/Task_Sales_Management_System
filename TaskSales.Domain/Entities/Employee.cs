using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

// Week 9 Day 4 - Employee Entity
// Week 9 Day 4 - Employee Entity
namespace TaskSales.Domain.Entities
{
    public class Employee
    {
        public int Id { get; set; }

        public string FullName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Role { get; set; } = "User";

        public bool IsActive { get; set; } = true;

        // 🔑 LINK TO ASP.NET IDENTITY USER
        public string IdentityUserId { get; set; } = string.Empty;
    }
}
