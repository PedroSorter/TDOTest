using Data.Repositories;
using Domain.Repository;
using Domain.Services;
using Microsoft.Extensions.DependencyInjection;
using Services;

namespace TDOTest.Configurations
{
    public static class ServiceConfiguration
    {
        public static void ConfigureServices(this IServiceCollection services)
        {
            services.AddScoped<IImageService, ImageService>();
            services.AddScoped<IImageRepository, ImageRepository>();
        }
    }
}
