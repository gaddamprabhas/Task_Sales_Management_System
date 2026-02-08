using System.Net.Http.Json;
using TaskSales.Application.DTOs;

namespace TaskSales.Blazor.Services;

public class EmployeeApiService
{
    private readonly HttpClient _http;

    public EmployeeApiService(IHttpClientFactory factory)
    {
        _http = factory.CreateClient("Api");
    }

    public async Task<List<EmployeeDto>> GetAllAsync()
        => await _http.GetFromJsonAsync<List<EmployeeDto>>("api/employees") ?? new();

    // 🔑 GUID → EmployeeId
    public async Task<int> GetEmployeeIdAsync(string identityId)
    {
        var res = await _http.GetAsync($"api/employees/by-identity/{identityId}");
        if (!res.IsSuccessStatusCode)
            throw new Exception("Employee not found for this login.");

        return await res.Content.ReadFromJsonAsync<int>();
    }



    public async Task EnsureEmployeeExistsAsync(string identityUserId, string email)
    {
        var dto = new EmployeeDto
        {
            Email = email,
            FullName = email.Split('@')[0],
            IdentityUserId = identityUserId,
            Role = "User"
        };

        await _http.PostAsJsonAsync("api/employees/ensure", dto);
    }

    // CRUD (for Admin → Employees page)
    public async Task CreateAsync(EmployeeDto dto)
        => (await _http.PostAsJsonAsync("api/employees", dto)).EnsureSuccessStatusCode();

    public async Task UpdateAsync(EmployeeDto dto)
        => (await _http.PutAsJsonAsync($"api/employees/{dto.Id}", dto)).EnsureSuccessStatusCode();

    public async Task DeleteAsync(int id)
        => (await _http.DeleteAsync($"api/employees/{id}")).EnsureSuccessStatusCode();
}
