using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HostingTradingBots.Persistentce.EntityTypeConfiguration
{
    public class TradingPlatformConfiguration : IEntityTypeConfiguration<TradingPlatform.Domain.TradingPlatform>
    {
        public void Configure(EntityTypeBuilder<TradingPlatform.Domain.TradingPlatform> builder)
        {
            // Установка первичного ключа
            builder.HasKey(tradingPlatform => tradingPlatform.Id);
            // Установка индекса для Id, который должен быть уникальным
            builder.HasIndex(tradingPlatform => tradingPlatform.Id).IsUnique();
            builder.Property(tradingPlatform => tradingPlatform.Name).IsRequired();
            builder.Property(tradingPlatform => tradingPlatform.SiteLink).IsRequired();
            builder.Property(tradingPlatform => tradingPlatform.IsActive).IsRequired();
            builder.Property(tradingPlatform => tradingPlatform.ReferralLink).IsRequired(false);
            builder.Property(tradingPlatform => tradingPlatform.ApiLink).IsRequired(false);
            builder.Property(tradingPlatform => tradingPlatform.TestApiLink).IsRequired(false);
            builder.Property(tradingPlatform => tradingPlatform.DocsLink).IsRequired(false);
            builder.Property(tradingPlatform => tradingPlatform.Icon).IsRequired(false);
            builder.Property(tradingPlatform => tradingPlatform.CreatedAt).IsRequired();
            builder.Property(tradingPlatform => tradingPlatform.UpdatedAt).IsRequired(false);
            builder.Property(tradingPlatform => tradingPlatform.ArchivedAt).IsRequired(false);
        }
    }
}

