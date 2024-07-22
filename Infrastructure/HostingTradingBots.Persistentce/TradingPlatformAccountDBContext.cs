using Microsoft.EntityFrameworkCore;
using HostingTradingBots.Application.Interfaces;
using HostingTradingBots.Persistentce.EntityTypeConfiguration;

namespace HostingTradingBots.Persistentce
{
  public class TradingPlatformAccountDBContext : DbContext, ITradingPlatformAccountDBContext
  {
    public DbSet<TradingPlatformAccount.Domain.TradingPlatformAccount> TradingPlatformsAccounts { get; set; }

    public TradingPlatformAccountDBContext(DbContextOptions<TradingPlatformAccountDBContext> options)
      : base(options) { }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      modelBuilder.ApplyConfiguration(new TradingPlatformAccountConfiguration());
      base.OnModelCreating(modelBuilder);
    }
  }
}
