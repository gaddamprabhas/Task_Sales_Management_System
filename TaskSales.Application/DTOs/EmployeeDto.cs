using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


// Week 9 Day 4 - Employee DTO
namespace TaskSales.Application.DTOs
{
    public class EmployeeDto
    {
        public int Id { get; set; }

        public string FullName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Role { get; set; } = "User";

        // 🔑 Needed for mapping logged-in user
        public string IdentityUserId { get; set; } = string.Empty;
    }
}
