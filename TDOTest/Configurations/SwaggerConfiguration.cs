using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace TDOTest.Configurations
{
    public static class SwaggerConfiguration
    {
        public static void ConfigureSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo()
                {
                    Title = "TDO API",
                    Version = "v1",
                    Description = "1.0 Api version documentation"
                });
            });
        }
    }
}
