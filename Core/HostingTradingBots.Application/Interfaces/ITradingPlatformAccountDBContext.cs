using Microsoft.EntityFrameworkCore;

namespace HostingTradingBots.Application.Interfaces
{
    public interface ITradingPlatformAccountDBContext
    {
        DbSet<TradingPlatformAccount.Domain.TradingPlatformAccount> TradingPlatformsAccounts { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
