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
      var connectionStringTp = configuration["DbConnectionTradingPlatform"];
      var connectionStringP = configuration["DbConnectionProfile"];
      var connectionStringTPA = configuration["DbConnectionTradingPlatformAccount"];
      services.AddDbContext<TradingPlatformDBContext>(options =>
      {
        options.UseSqlite(connectionStringTp);
      });
      services.AddScoped<ITradingPlatformDBContext>(provider =>
          provider.GetService<TradingPlatformDBContext>());


      services.AddDbContext<ProfileDBContext>(options =>
      {
        options.UseSqlite(connectionStringP);
      });
      services.AddScoped<IProfileDBContext>(provider =>
          provider.GetService<ProfileDBContext>());


      services.AddDbContext<TradingPlatformAccountDBContext>(options =>
      {
        options.UseSqlite(connectionStringTp);
      });
      services.AddScoped<ITradingPlatformAccountDBContext>(provider =>
          provider.GetService<TradingPlatformAccountDBContext>());
      return services;

    }
  }
}
