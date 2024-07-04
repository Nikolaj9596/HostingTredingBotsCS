using Microsoft.EntityFrameworkCore;

namespace HostingTradingBots.Application.Interfaces
{
  public interface ITradingPlatrformDBContext
  {
    DbSet<TradingPlatform.Domain.TradingPlatform> TradingPlatforms { get; set; }
    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
  }
}
