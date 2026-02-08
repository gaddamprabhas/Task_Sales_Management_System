using System.Net.Http.Json;
using TaskSales.Application.DTOs;

namespace TaskSales.Blazor.Services
{
    // Week 9 Day 3 - Reports API Service
    public class ReportApiService
    {
        private readonly HttpClient _http;

        public ReportApiService(HttpClient http)
        {
            _http = http;
        }

        // Calls REAL working API
        public async Task<List<SalesReportDto>> GetSalesByEmployeeAsync()
        {
            return await _http.GetFromJsonAsync<List<SalesReportDto>>
                ("/api/task-reports/by-employee") ?? new();
        }

    }
}
