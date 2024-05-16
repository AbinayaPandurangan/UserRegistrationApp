namespace Podme.UserRegistrationApp.Api.Extensions
{
    public static class SwaggerConfigExtensions
    {
        public static void UseSwaggerConfig(this WebApplication app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "User Registration");
                options.RoutePrefix = string.Empty;
            });
        }

        public static void ConfigureSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen();
        }
    }
}
