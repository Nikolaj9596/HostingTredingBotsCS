using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using Profile.Application.Interfaces;

namespace Profile.Persistentce 
{
  public static class DependencyInjection
  {
    public static IServiceCollection AddPersistence(this IServiceCollection
        services, IConfiguration configuration)
    {
      var connectionString = configuration["DbConnection"];
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
