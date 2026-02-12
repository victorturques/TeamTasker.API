using Microsoft.EntityFrameworkCore;
using TeamTasker.API.Data;

namespace TeamTasker.API.Extensions
{
    public static class ServiceExtensions
    {
        
        public static void ConfigureDatabase(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection");

            services.AddDbContext<AppDbContext>(options =>
                options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));
        }
    }
}