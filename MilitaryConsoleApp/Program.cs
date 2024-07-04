using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MilitaryConsoleApp.Clients;
using MilitaryConsoleApp.Configuration;
using MilitaryConsoleApp.ErrorHandling;
using MilitaryConsoleApp.Repositories;
using MilitaryConsoleApp.Services;
using Serilog;

namespace MilitaryConsoleApp
{
    public class Program
    {
        public static IConfigurationRoot Configuration;

        static async Task Main(string[] args)
        {
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .WriteTo.Console()
                .WriteTo.File("logs/log.txt",
                                rollingInterval: RollingInterval.Day,
                                retainedFileCountLimit: 7,
                                fileSizeLimitBytes: 10485760,
                              rollOnFileSizeLimit: true
                    ).CreateLogger();

            Log.Information("Application Starting Up");
            var host = CreateHostBuilder(args).Build();

            var errorHandler= host.Services.GetRequiredService<IErrorHandler>();

            await errorHandler.HandleAsync(async () =>
            {
                var billingService = host.Services.GetRequiredService<IBillingService>();
                var authService = host.Services.GetRequiredService<IAuthService>();

                await authService.GetAccessTokenAsync();

                await billingService.ProcessOrdersBillingEntriesAsync();
                await billingService.ProcessOffersBillingEntriesAsync();

                Log.Information("Application is Closing");                
            });
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureServices((context, services) =>
                {
                    services.AddTransient<IErrorHandler, ErrorHandler>();
                    services.AddTransient<IOrderService, OrderService>();
                    services.AddTransient<IOfferService, OfferService>();
                    services.AddTransient<IBillingService, BillingService>();
                    services.AddTransient<IOrderRepository, OrderRepository>();
                    services.AddTransient<IOfferRepository, OfferRepository>();
                    services.AddTransient<IBillingRepository, BillingRepository>();
                    //services.AddTransient<IAuthService, AuthService>();
                    services.AddTransient<IAuthService, SandboxAuthService>();
                    services.AddTransient<IAllegroClient, AllegroClient>();

                    services.Configure<DatabaseConfig>(context.Configuration.GetSection("DatabaseConfig"));
                    services.Configure<ApiConfig>(context.Configuration.GetSection("ApiConfig"));
                });
    }

}
