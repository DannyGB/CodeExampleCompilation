using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using CodeExampleCompilation.Application;
using CodeExampleCompilation.Infrastructure.Display;
using CodeExampleCompilation.Infrastructure.IO;
using CodeExampleCompilation.Infrastructure;

namespace CodeExampleCompilation.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddServices(this IServiceCollection services, IConfiguration configuration)
        {
            services
                .AddTransient<IContentReader, ContentReader>()
                .AddTransient<IScreen, Screen>()
                .AddSingleton<ITitle, Title>()
                .AddSingleton<CodeExampleCompilation.Infrastructure.IO.IDirectory, CodeExampleCompilation.Infrastructure.IO.Directory>()
                .AddSingleton<CodeExampleCompilation.Infrastructure.IO.IFile, CodeExampleCompilation.Infrastructure.IO.File>()
                .AddTransient<Home>()
                .Configure<AppSettings>(configuration.GetSection("AppSettings"));

            return services;
        }
    }
}