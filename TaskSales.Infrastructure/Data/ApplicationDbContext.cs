using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TaskSales.Domain.Entities;

namespace TaskSales.Infrastructure.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }

        public DbSet<TaskItem> Tasks => Set<TaskItem>();
        public DbSet<Employee> Employees => Set<Employee>();
        public DbSet<Sale> Sales => Set<Sale>();
        public DbSet<SchedulerEvent> SchedulerEvents => Set<SchedulerEvent>();
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<TaskItem>()
                .Property(t => t.Status)
                .HasConversion<int>();

            builder.Entity<TaskItem>()
                .Property(t => t.Priority)
                .HasConversion<int>();

            builder.Entity<Sale>()
                .Property(s => s.TotalAmount)
                .HasPrecision(18, 2);
        }
    }
}
