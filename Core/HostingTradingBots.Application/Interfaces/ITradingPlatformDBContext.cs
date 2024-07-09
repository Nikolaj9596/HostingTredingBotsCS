using Microsoft.EntityFrameworkCore;

namespace HostingTradingBots.Application.Interfaces
{
  public interface ITradingPlatformDBContext
  {
    DbSet<TradingPlatform.Domain.TradingPlatform> TradingPlatforms { get; set; }
    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
  }
}
