namespace HostingTradingBots.Persistentce
{
    public class Dbinitializer
    {
        public static void Initialize(
            ProfileDBContext profileContext,
            TradingPlatformDBContext tradingPlatformContext
        )
        {
            profileContext.Database.EnsureCreated();
            tradingPlatformContext.Database.EnsureCreated();
        }
    }
}
