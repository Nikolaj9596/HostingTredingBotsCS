using Microsoft.EntityFrameworkCore;
using HostingTradingBots.Application.Interfaces;
using HostingTradingBots.Persistentce.EntityTypeConfiguration;

namespace HostingTradingBots.Persistentce
{
    public class TradingPlatformDBContext : DbContext, ITradingPlatformDBContext
    {
        public DbSet<TradingPlatform.Domain.TradingPlatform> TradingPlatforms { get; set; }
        public TradingPlatformDBContext(DbContextOptions<TradingPlatformDBContext> options)
          : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new TradingPlatformConfiguration());
            base.OnModelCreating(modelBuilder);
        }
    }
}
