using Microsoft.EntityFrameworkCore;
using MuctrService.Domain;
using System.Threading;
using System.Threading.Tasks;

namespace MuctrService.Application.Interfaces
{
    public interface IMuctrServiceDbContext
    {
        public DbSet<News> News { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<Faculty> Faculties { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Professor> Professors { get; set; }
        public DbSet<EducationType> EducationTypes { get; set; }
        public DbSet<Schedule> Schedules { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);

    }
}
