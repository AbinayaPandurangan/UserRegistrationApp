using Microsoft.EntityFrameworkCore;
using Podme.UserRegistrationApp.Api.Repositories.Data;

namespace Podme.UserRegistrationApp.Api.Extensions
{
    public static class DatabaseConfigExtensions
    {
        public static void ConfigureSqlLite(this IServiceCollection services, ConfigurationManager configuration)
        {
            services.AddDbContext<DataContext>(opt =>
            {
                opt.UseSqlite(configuration.GetConnectionString("DefaultConnection"), b => b.MigrationsAssembly("Podme.UserRegistrationApp.Api"));
            });
        }
    }
}
