using Podme.UserRegistrationApp.Api.Repositories.Classes;
using Podme.UserRegistrationApp.Api.Repositories.Contracts;

namespace Podme.UserRegistrationApp.Api.Extensions
{
    public static class ApplicationServiceConfigExtensions
    {
        public static void ConfigureAppServices(this IServiceCollection services)
        {
            services.AddScoped<IUserRepository, UserRepository>();
        }
    }
}
