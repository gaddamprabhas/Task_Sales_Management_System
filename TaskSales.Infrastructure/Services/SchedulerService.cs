using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskSales.Application.DTOs;
using TaskSales.Application.Interfaces;
using TaskSales.Domain.Entities;
using TaskSales.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace TaskSales.Infrastructure.Services
{
    public class SchedulerService : ISchedulerService
    {
        private readonly ApplicationDbContext _context;

        public SchedulerService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<SchedulerEventDto>> GetAllAsync()
        {
            return await _context.SchedulerEvents
                .AsNoTracking()
                .Select(e => new SchedulerEventDto
                {
                    Id = e.Id,
                    Title = e.Title,
                    StartTime = e.StartTime,
                    EndTime = e.EndTime
                })
                .ToListAsync();
        }

        public async Task AddAsync(SchedulerEventDto dto)
        {
            var entity = new SchedulerEvent
            {
                Title = dto.Title,
                StartTime = dto.StartTime,
                EndTime = dto.EndTime
            };

            _context.SchedulerEvents.Add(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(int id, SchedulerEventDto dto)
        {
            var entity = await _context.SchedulerEvents.FindAsync(id);
            if (entity == null) return;

            entity.Title = dto.Title;
            entity.StartTime = dto.StartTime;
            entity.EndTime = dto.EndTime;

            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _context.SchedulerEvents.FindAsync(id);
            if (entity == null) return;

            _context.SchedulerEvents.Remove(entity);
            await _context.SaveChangesAsync();
        }
    }
}
