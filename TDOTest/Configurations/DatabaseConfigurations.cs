using Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace TDOTest.Configurations
{
    public static class DatabaseConfiguration
    {
        public static void ConfigureDatabase(this IServiceCollection services, IConfiguration config)
        {
            string connectionString = config.GetSection("ConnectionStrings")["TDOConnectionString"];
            services.AddDbContext<Context>(options =>
                options.UseSqlServer(connectionString)
            );
        }
    }
}
