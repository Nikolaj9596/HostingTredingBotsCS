namespace HostingTradingBots.Persistentce
{
    public class Dbinitializer
    {
        public static void Initialize(
            ProfileDBContext profileContext,
            TradingPlatformDBContext tradingPlatformContext,
            TradingPlatformAccountDBContext tradingPlatformAccountContext,
        )
        {
            profileContext.Database.EnsureCreated();
            tradingPlatformContext.Database.EnsureCreated();
            tradingPlatformAccountContext.Database.EnsureCreated();
        }
    }
}
