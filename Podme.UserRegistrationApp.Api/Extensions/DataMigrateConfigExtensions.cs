using Microsoft.EntityFrameworkCore;
using Podme.UserRegistrationApp.Api.Repositories.Data;

namespace Podme.UserRegistrationApp.Api.Extensions
{
    public static class DataMigrateConfigExtensions
    {
        public static void ExecuteDataMigrate(this WebApplication app)
        {
            var scope = app.Services.CreateScope();
            var context = scope.ServiceProvider.GetRequiredService<DataContext>();

            try
            {
                context.Database.Migrate();
                DbInitializer.Initialize(context);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message, "A problem occured during migration.");
            }
        }
    }
}
