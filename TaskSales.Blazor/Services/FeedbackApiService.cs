using System.Net.Http.Json;
using TaskSales.Blazor.Models;

namespace TaskSales.Blazor.Services;

public class FeedbackApiService
{
    private readonly HttpClient _http;

    public FeedbackApiService(IHttpClientFactory factory)
    {
        _http = factory.CreateClient("Api");
    }

    public async Task<List<UserFeedback>> GetAllAsync()
    {
        return await _http.GetFromJsonAsync<List<UserFeedback>>("/api/feedback")
               ?? new();
    }
}
