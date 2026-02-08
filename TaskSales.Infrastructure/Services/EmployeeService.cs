using Microsoft.EntityFrameworkCore;
using TaskSales.Application.DTOs;
using TaskSales.Application.Interfaces;
using TaskSales.Domain.Entities;
using TaskSales.Infrastructure.Data;

namespace TaskSales.Infrastructure.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly ApplicationDbContext _context;

        public EmployeeService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<EmployeeDto>> GetAllAsync()
        {
            return await _context.Employees
                .AsNoTracking()
                .Select(e => new EmployeeDto
                {
                    Id = e.Id,
                    FullName = e.FullName,
                    Email = e.Email,
                    Role = e.Role,
                    IdentityUserId = e.IdentityUserId
                })
                .ToListAsync();
        }


        public async Task AddAsync(EmployeeDto employee)
        {
            var entity = new Employee
            {
                FullName = employee.FullName,
                Email = employee.Email,
                Role = employee.Role,
                IdentityUserId = employee.IdentityUserId // 🔑
            };

            _context.Employees.Add(entity);
            await _context.SaveChangesAsync();
        }


        public async Task UpdateAsync(EmployeeDto employee)
        {
            var entity = await _context.Employees.FindAsync(employee.Id);
            if (entity == null) return;

            entity.FullName = employee.FullName;
            entity.Email = employee.Email;
            entity.Role = employee.Role;

            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _context.Employees.FindAsync(id);
            if (entity == null) return;

            _context.Employees.Remove(entity);
            await _context.SaveChangesAsync();
        }
        public async Task<EmployeeDto?> GetByIdentityIdAsync(string identityUserId)
        {
            var emp = await _context.Employees
                .FirstOrDefaultAsync(e => e.IdentityUserId == identityUserId);

            if (emp == null) return null;

            return new EmployeeDto
            {
                Id = emp.Id,
                FullName = emp.FullName,
                Email = emp.Email,
                Role = emp.Role,
                IdentityUserId = emp.IdentityUserId
            };
        }


    }
}
