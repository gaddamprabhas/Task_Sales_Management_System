using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using TaskSales.Application.Interfaces;
using static System.Runtime.InteropServices.JavaScript.JSType;


namespace TaskSales.Application.DTOs;

public class SaleDto
{
    public int Id { get; set; }

    public string ProductName { get; set; } = string.Empty;
    public int Quantity { get; set; }
    public decimal TotalAmount { get; set; }

    public int EmployeeId { get; set; }        // FK
    public string EmployeeName { get; set; } = string.Empty;

    public DateTime SaleDate { get; set; }
}