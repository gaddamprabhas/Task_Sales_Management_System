using System;
using TaskSales.Domain.Enums;
using DomainTaskStatus = TaskSales.Domain.Enums.TaskStatus;
namespace TaskSales.Application.DTOs
{
    public class TaskDto
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public DateTime DueDate { get; set; }

        public int AssignedEmployeeId { get; set; }

        public DomainTaskStatus Status { get; set; } = DomainTaskStatus.Pending;
        public TaskPriority Priority { get; set; } = TaskPriority.Medium;
    }
}
