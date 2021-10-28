using System.IO;
using CodeExampleCompilation.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using CodeExampleCompilation.Infrastructure.Display;
using CodeExampleCompilation.Application;
using Microsoft.Extensions.Logging;
using NLog;
using NLog.Extensions.Logging;
using CodeExampleCompilation.Infrastructure.Partials;

namespace CodeExampleCompilation
{
    class Program
    {
        static AppSettings appSettings = new AppSettings();
        static void Main(string[] args)
        {        
            var logger = LogManager.GetCurrentClassLogger();

            var services = new ServiceCollection();
            ConfigureServices(services);

            var provider = services.BuildServiceProvider();

            provider.GetRequiredService<Home>().Render();
        }

        private static void ConfigureServices(IServiceCollection services)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory()) 
                .AddJsonFile("appsettings.json", optional: false)
#if DEBUG
                .AddJsonFile("appsettings.developer.json", optional: true)
#endif  
                .Build();

            services.AddLogging(builder =>
            {
                builder.AddConsole();
                builder.ClearProviders();
                builder.SetMinimumLevel(Microsoft.Extensions.Logging.LogLevel.Trace);
                builder.AddNLog(configuration);
            });

            services
                .AddTransient<IContentReader, ContentReader>()
                .AddTransient<IScreen, Screen>()
                .AddSingleton<IWelcome, Welcome>()
                .AddTransient<Home>()
                .Configure<AppSettings>(configuration.GetSection("AppSettings"));
        }
    }
}
