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
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);

    }
}
