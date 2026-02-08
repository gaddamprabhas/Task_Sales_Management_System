using TaskSales.Application.DTOs;

namespace TaskSales.Application.Interfaces
{
    public interface ITaskService
    {
        Task<List<TaskDto>> GetAllAsync();
        Task AddAsync(TaskDto task);

        Task<List<TaskReportDto>> GetTaskCountByEmployeeAsync();
        Task<List<TaskReportDto>> GetTaskStatusSummaryAsync();
    }
}
