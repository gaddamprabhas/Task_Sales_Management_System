using System.Net.Http.Json;
using TaskSales.Blazor.Models;

namespace TaskSales.Blazor.Services;

public class LogApiService
{
    private readonly HttpClient _http;

    public LogApiService(IHttpClientFactory factory)
    {
        _http = factory.CreateClient("Api");
    }

    public async Task<List<ActivityLog>> GetAllAsync()
    {
        return await _http.GetFromJsonAsync<List<ActivityLog>>("/api/logs")
               ?? new();
    }
}
