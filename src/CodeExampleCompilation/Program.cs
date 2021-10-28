using System.IO;
using CodeExampleCompilation.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using CodeExampleCompilation.Infrastructure.Display;
using CodeExampleCompilation.Application;

namespace CodeExampleCompilation
{
    class Program
    {
        static AppSettings appSettings = new AppSettings();
        static void Main(string[] args)
        {            
            var services = new ServiceCollection();
            ConfigureServices(services);

            var provider = services.BuildServiceProvider();

            provider.GetRequiredService<Home>().Render();
        }

        private static void ConfigureServices(IServiceCollection services)
        {
            // configure logging
            // services.AddLogging(builder =>
            // {
            //     builder.AddConsole();
            //     builder.AddDebug();
            // });

            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false)
#if DEBUG
                .AddJsonFile("appsettings.developer.json", optional: true)
#endif  
                .Build();

            services
                .AddTransient<IContentReader, ContentReader>()
                .AddTransient<IScreen, Screen>()
                .AddTransient<Home>()
                .Configure<AppSettings>(configuration.GetSection("AppSettings"));
        }
    }
}
