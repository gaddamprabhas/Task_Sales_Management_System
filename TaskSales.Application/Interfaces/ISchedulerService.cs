using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskSales.Application.DTOs;

namespace TaskSales.Application.Interfaces
{
    public interface ISchedulerService
    {
        Task<List<SchedulerEventDto>> GetAllAsync();
        Task AddAsync(SchedulerEventDto dto);
        Task UpdateAsync(int id, SchedulerEventDto dto);
        Task DeleteAsync(int id);
    }
}
