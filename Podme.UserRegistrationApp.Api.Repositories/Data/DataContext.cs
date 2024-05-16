using Microsoft.EntityFrameworkCore;
using Podme.UserRegistrationApp.Api.Entitites;

namespace Podme.UserRegistrationApp.Api.Repositories.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<UserEntity> UserEntity { get; set; }
    }
}
