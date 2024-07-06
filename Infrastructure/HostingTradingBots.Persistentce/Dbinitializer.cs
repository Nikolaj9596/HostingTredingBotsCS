namespace HostingTradingBots.Persistentce 
{
  public class Dbinitializer
  {
    public static void Initialize(ProfileDBContext context)
    {
      context.Database.EnsureCreated();
    }
  }
}
