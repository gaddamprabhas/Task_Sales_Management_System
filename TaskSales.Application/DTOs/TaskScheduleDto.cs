using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TaskSales.Domain.Enums;

namespace TaskSales.Application.DTOs
{
    public class TaskScheduleDto
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }

        // ✅ EXPLICIT DOMAIN ENUM
        public TaskSales.Domain.Enums.TaskStatus Status { get; set; }
    }
}
