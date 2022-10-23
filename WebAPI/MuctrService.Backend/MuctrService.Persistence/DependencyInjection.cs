using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using MuctrService.Application.Interfaces;

namespace MuctrService.Persistence
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services, 
            IConfiguration configuration)
        {
            string connectionString = configuration["DbConnection"];

            services.AddDbContext<MuctrServiceDbContext>(options =>
            {
                options.UseSqlServer(connectionString);
            });

            services.AddScoped<IMuctrServiceDbContext>(provider =>
                provider.GetService<MuctrServiceDbContext>());

            return services;
        }
    }
}
