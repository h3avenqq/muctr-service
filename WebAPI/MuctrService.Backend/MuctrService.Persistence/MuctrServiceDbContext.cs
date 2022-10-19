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

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new NewsConfiguration());
            builder.ApplyConfiguration(new EventConfiguration());

            base.OnModelCreating(builder);
        }
    }
}
