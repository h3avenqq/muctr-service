using Microsoft.EntityFrameworkCore;
using MuctrService.Application.Interfaces;
using MuctrService.Domain;
using MuctrService.Persistence.EntityTypeConfiguration;

namespace MuctrService.Persistence
{
    public class MuctrServiceDbContext : DbContext, IMuctrServiceDbContext
    {
        public MuctrServiceDbContext(DbContextOptions<MuctrServiceDbContext> options)
            : base(options) { }

        public DbSet<News> News { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<Faculty> Faculties { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Professor> Professors { get; set; }
        public DbSet<EducationType> EducationTypes { get; set; }
        public DbSet<Schedule> Schedules { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new NewsConfiguration());
            builder.ApplyConfiguration(new EventConfiguration());
            builder.ApplyConfiguration(new FacultyConfiguration());
            builder.ApplyConfiguration(new DepartmentConfiguration());
            builder.ApplyConfiguration(new ProfessorConfiguration());
            builder.ApplyConfiguration(new ScheduleConfiguration());
            builder.ApplyConfiguration(new EducationTypeConfiguration());

            base.OnModelCreating(builder);
        }
    }
}
