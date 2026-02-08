using System.Net.Http.Json;
using TaskSales.Application.DTOs;

namespace TaskSales.Blazor.Services
{
    public class DashboardApiService
    {
        private readonly HttpClient _http;

        public DashboardApiService(IHttpClientFactory factory)
        {
            _http = factory.CreateClient("Api");
        }

        public async Task<DashboardKpiDto> GetKpisAsync()
        {
            return await _http.GetFromJsonAsync<DashboardKpiDto>(
                "/api/dashboard/kpis"
            ) ?? new DashboardKpiDto();
        }

        public async Task<List<SalesTrendDto>> GetSalesTrendAsync()
        {
            return await _http.GetFromJsonAsync<List<SalesTrendDto>>(
                "/api/dashboard/sales-trend"
            ) ?? new();
        }
    }
}
