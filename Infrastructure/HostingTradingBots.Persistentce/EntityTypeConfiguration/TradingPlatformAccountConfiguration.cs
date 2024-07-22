using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HostingTradingBots.Persistentce.EntityTypeConfiguration
{
  public class TradingPlatformAccountConfiguration : IEntityTypeConfiguration<TradingPlatformAccount.Domain.TradingPlatformAccount>
  {
    public void Configure(EntityTypeBuilder<TradingPlatformAccount.Domain.TradingPlatformAccount> builder)
    {
      // Установка первичного ключа
      builder.HasKey(tradingPlatformAccount => tradingPlatformAccount.Id);
      // Установка индекса для Id, который должен быть уникальным
      builder.HasIndex(tradingPlatformAccount => tradingPlatformAccount.Id).IsUnique();
      builder.Property(tradingPlatformAccount => tradingPlatformAccount.TradingPlatformId).IsRequired();
      builder.Property(tradingPlatformAccount => tradingPlatformAccount.UserId).IsRequired();
      builder.Property(tradingPlatformAccount => tradingPlatformAccount.IsActive).IsRequired();
      builder.Property(tradingPlatformAccount => tradingPlatformAccount.ApiKey).IsRequired();
      builder.Property(tradingPlatformAccount => tradingPlatformAccount.TestApiKey).IsRequired(false);
      builder.Property(tradingPlatformAccount => tradingPlatformAccount.CreatedAt).IsRequired();
      builder.Property(tradingPlatformAccount => tradingPlatformAccount.UpdatedAt).IsRequired(false);
      builder.Property(tradingPlatformAccount => tradingPlatformAccount.ArchivedAt).IsRequired(false);
    }
  }
}

