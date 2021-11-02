using System.IO;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using NLog;
using NLog.Extensions.Logging;
using CodeExampleCompilation.Extensions;

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
            })
            .AddServices(configuration);
        }
    }
}
