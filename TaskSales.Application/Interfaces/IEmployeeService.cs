using TaskSales.Application.DTOs;

public interface IEmployeeService
{
    Task<List<EmployeeDto>> GetAllAsync();
    Task AddAsync(EmployeeDto employee);
    Task UpdateAsync(EmployeeDto employee);
    Task DeleteAsync(int id);

    // 🔑 REQUIRED
    Task<EmployeeDto?> GetByIdentityIdAsync(string identityUserId);
}
