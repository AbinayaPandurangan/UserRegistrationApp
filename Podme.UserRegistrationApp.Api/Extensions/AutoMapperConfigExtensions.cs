using Podme.UserRegistrationApp.Api.Configurations;
using Podme.UserRegistrationApp.Api.Repositories.Contracts;
using Podme.UserRegistrationApp.Api.Repositories.Classes;

namespace Podme.UserRegistrationApp.Api.Extensions
{
    public static class AutoMapperConfigExtensions
    {
        public static void ConfigureAutoMapper(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(MappingConfig));
        }
    }
}
