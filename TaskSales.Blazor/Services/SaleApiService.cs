using System.Net.Http.Json;
using TaskSales.Application.DTOs;

namespace TaskSales.Blazor.Services
{
    public class SalesApiService
    {
        private readonly HttpClient _http;

        public SalesApiService(IHttpClientFactory factory)
        {
            _http = factory.CreateClient("Api");
        }

        public async Task<List<SaleDto>> GetAllAsync()
        {
            return await _http.GetFromJsonAsync<List<SaleDto>>("api/sales")
                   ?? new();
        }

        public async Task CreateAsync(SaleDto sale)
        {
            var response = await _http.PostAsJsonAsync("api/sales", sale);
            response.EnsureSuccessStatusCode();
        }
    }
}
