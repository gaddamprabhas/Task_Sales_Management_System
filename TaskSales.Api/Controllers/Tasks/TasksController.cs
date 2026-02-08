using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Threading.Tasks;
using System.Net.NetworkInformation;
using System.Security.Cryptography;
using System.Threading;

using TaskSales.Application.DTOs;
using TaskSales.Domain.Entities;
using TaskSales.Infrastructure.Data;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using DomainTaskStatus = TaskSales.Domain.Enums.TaskStatus;


namespace TaskSales.Api.Controllers.Tasks
{

    [ApiController]
    [Route("api/tasks")]
    public class TasksController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public TasksController(ApplicationDbContext context)
        {
            _context = context;
        }

        // ✅ GRID (Admin + Employee)
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _context.Tasks.ToListAsync());
        }

        // ✅ EMPLOYEE SCHEDULER
        [HttpGet("schedule/employee/{employeeId}")]
        public async Task<IActionResult> GetScheduleForEmployee(int employeeId)
        {
            var data = await _context.Tasks
                .Where(t => t.AssignedEmployeeId == employeeId)
                .Select(t => new TaskScheduleDto
                {
                    Id = t.Id,
                    Title = t.Title,
                    StartTime = t.StartTime == DateTime.MinValue ? t.DueDate : t.StartTime,
                    EndTime = t.EndTime == DateTime.MinValue ? t.DueDate.AddHours(1) : t.EndTime,
                    Status = t.Status
                })
                .ToListAsync();

            return Ok(data);
        }

        // ✅ ADMIN CREATE
        [HttpPost]
        public async Task<IActionResult> Create(TaskItem task)
        {
            _context.Tasks.Add(task);
            await _context.SaveChangesAsync();
            return Ok(task);
        }

        // ✅ ADMIN UPDATE
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, TaskItem task)
        {
            if (id != task.Id) return BadRequest();

            _context.Entry(task).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return Ok(task);
        }

        // ✅ EMPLOYEE STATUS UPDATE
        [HttpPatch("{id}/status")]
        public async Task<IActionResult> UpdateStatus(int id, [FromBody] int status)
        {
            var task = await _context.Tasks.FindAsync(id);
            if (task == null) return NotFound();

            task.Status = (TaskSales.Domain.Enums.TaskStatus)status;
            await _context.SaveChangesAsync();

            return Ok();
        }
        // ✅ EMPLOYEE STATUS + FEEDBACK UPDATE
        [HttpPatch("{id}/status-update")]
        public async Task<IActionResult> UpdateStatusWithFeedback(
    int id,
    [FromBody] TaskStatusUpdateDto dto)
        {
            var task = await _context.Tasks.FindAsync(id);
            if (task == null)
                return NotFound();

            task.Status = dto.Status;

            if (dto.Status == DomainTaskStatus.Completed)
            {
                task.EndTime = DateTime.UtcNow;
            }

            await _context.SaveChangesAsync();
            return Ok();
        }


        [HttpGet("my/{employeeId}")]
        public async Task<IActionResult> GetMyTasks(int employeeId)
        {
            var tasks = await _context.Tasks
                .Where(t => t.AssignedEmployeeId == employeeId)
                .ToListAsync();

            return Ok(tasks);
        }
       
    }
}

