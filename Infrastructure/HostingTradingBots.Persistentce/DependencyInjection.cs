using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using HostingTradingBots.Application.Interfaces;

namespace HostingTradingBots.Persistentce
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistence(this IServiceCollection
            services, IConfiguration configuration)
        {
            var connectionString = configuration["DbConnection"];
            services.AddDbContext<TradingPlatformDBContext>(options =>
            {
                options.UseSqlite(connectionString);
            });

            services.AddScoped<ITradingPlatformDBContext>(provider =>
                provider.GetService<TradingPlatformDBContext>());

            services.AddDbContext<ProfileDBContext>(options =>
            {
                options.UseSqlite(connectionString);
            });
            services.AddScoped<IProfileDBContext>(provider =>
                provider.GetService<ProfileDBContext>());

            return services;

        }
    }
}
