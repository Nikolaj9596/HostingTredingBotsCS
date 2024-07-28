using HostingTradingBots.Persistentce;

namespace HostingTradingBots.WebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {

            var host = CreateHostBuilder(args).Build();

            using (var scope = host.Services.CreateScope())
            {
                var serviceProvider = scope.ServiceProvider;
                try
                {
                    var context = serviceProvider.GetRequiredService<ProfileDBContext>();
                    var tradingPlatformContext = serviceProvider.GetRequiredService<TradingPlatformDBContext>();
                    var tradingPlatformAccountContext = serviceProvider.GetRequiredService<TradingPlatformAccountDBContext>();
                    Dbinitializer.Initialize(context, tradingPlatformContext, tradingPlatformAccountContext);
                }
                catch (Exception exception)
                {
                    // Log.Fatal(exception, "An error occurred while app initialization");
                }
            }

            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}

