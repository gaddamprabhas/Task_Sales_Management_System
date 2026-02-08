using Microsoft.EntityFrameworkCore;
using TaskSales.Application.DTOs;
using TaskSales.Application.Interfaces;
using TaskSales.Domain.Entities;
using TaskSales.Infrastructure.Data;

namespace TaskSales.Infrastructure.Services
{
    public class TaskService : ITaskService
    {
        private readonly ApplicationDbContext _context;

        public TaskService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<TaskDto>> GetAllAsync()
        {
            return await _context.Tasks
                .Select(t => new TaskDto
                {
                    Id = t.Id,
                    Title = t.Title,
                    DueDate = t.DueDate,
                    AssignedEmployeeId = t.AssignedEmployeeId,
                    Status = t.Status,
                    Priority = t.Priority
                })
                .ToListAsync();
        }

        public async Task AddAsync(TaskDto task)
        {
            var entity = new TaskItem
            {
                Title = task.Title,
                DueDate = task.DueDate,
                AssignedEmployeeId = task.AssignedEmployeeId,
                Status = task.Status,
                Priority = task.Priority
            };

            _context.Tasks.Add(entity);
            await _context.SaveChangesAsync();
        }

        // ✅ REQUIRED BY INTERFACE
        public async Task<List<TaskReportDto>> GetTaskCountByEmployeeAsync()
        {
            return await _context.Tasks
                .Join(_context.Employees,
                    t => t.AssignedEmployeeId,
                    e => e.Id,
                    (t, e) => e.FullName)
                .GroupBy(name => name)
                .Select(g => new TaskReportDto
                {
                    Label = g.Key,
                    Count = g.Count()
                })
                .ToListAsync();
        }

        // ✅ REQUIRED BY INTERFACE
        public async Task<List<TaskReportDto>> GetTaskStatusSummaryAsync()
        {
            return await _context.Tasks
                .GroupBy(t => t.Status)
                .Select(g => new TaskReportDto
                {
                    Label = g.Key.ToString(),
                    Count = g.Count()
                })
                .ToListAsync();
        }
    }
}
