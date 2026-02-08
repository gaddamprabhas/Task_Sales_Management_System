using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


using TaskSales.Domain.Enums;

namespace TaskSales.Application.DTOs
{
    public class TaskStatusUpdateDto
    {
        public TaskSales.Domain.Enums.TaskStatus Status { get; set; }
        public string? Feedback { get; set; }
    }
}