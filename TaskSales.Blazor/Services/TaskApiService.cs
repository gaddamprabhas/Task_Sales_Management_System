using System.Net.Http.Json;
using TaskSales.Application.DTOs;
using DomainTaskStatus = TaskSales.Domain.Enums.TaskStatus;

namespace TaskSales.Blazor.Services
{
    public class TaskApiService
    {
        private readonly HttpClient _http;

        public TaskApiService(IHttpClientFactory factory)
        {
            _http = factory.CreateClient("Api");
        }

        // TASK GRID
        public async Task<List<TaskDto>> GetTasksAsync()
            => await _http.GetFromJsonAsync<List<TaskDto>>("/api/tasks") ?? new();

        public async Task CreateTaskAsync(TaskDto task)
            => await _http.PostAsJsonAsync("/api/tasks", task);

        public async Task UpdateTaskAsync(TaskDto task)
            => await _http.PutAsJsonAsync($"/api/tasks/{task.Id}", task);

        public async Task DeleteTaskAsync(int id)
            => await _http.DeleteAsync($"/api/tasks/{id}");

        // DASHBOARD
        public async Task<List<TaskReportDto>> GetTasksByEmployeeAsync()
            => await _http.GetFromJsonAsync<List<TaskReportDto>>(
                "/api/task-reports/by-employee") ?? new();

        public async Task<List<TaskReportDto>> GetTaskStatusAsync()
            => await _http.GetFromJsonAsync<List<TaskReportDto>>(
                "/api/task-reports/status") ?? new();

        // EMPLOYEE SCHEDULER
        public async Task<List<TaskScheduleDto>> GetScheduleForEmployee(int empId)
            => await _http.GetFromJsonAsync<List<TaskScheduleDto>>(
                $"/api/tasks/schedule/employee/{empId}") ?? new();

        public async Task UpdateStatusAsync(int taskId, DomainTaskStatus status)
        {
            var response = await _http.PatchAsJsonAsync(
                $"/api/tasks/{taskId}/status",
                (int)status
            );

            response.EnsureSuccessStatusCode();
        }
    }
}
