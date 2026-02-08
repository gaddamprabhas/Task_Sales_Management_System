using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TaskSales.Application.Interfaces;
using DomainTaskStatus = TaskSales.Domain.Enums.TaskStatus;

namespace TaskSales.Api.Controllers.Tasks
{
    // Week 9 Day 3 - Task Reports API
    [ApiController]
    [Route("api/task-reports")]
    //[Authorize(Roles = "Admin")]
    public class TaskReportsController : ControllerBase
    {
        private readonly ITaskService _taskService;

        public TaskReportsController(ITaskService taskService)
        {
            _taskService = taskService;
        }

        [HttpGet("by-employee")]
        public async Task<IActionResult> TasksByEmployee()
            => Ok(await _taskService.GetTaskCountByEmployeeAsync());

        [HttpGet("status")]
        public async Task<IActionResult> TaskStatus()
            => Ok(await _taskService.GetTaskStatusSummaryAsync());
    }
}
