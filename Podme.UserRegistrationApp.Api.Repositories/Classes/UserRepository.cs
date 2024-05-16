using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Podme.UserRegistrationApp.Api.Entitites;
using Podme.UserRegistrationApp.Api.Repositories.Contracts;

namespace Podme.UserRegistrationApp.Api.Repositories.Classes
{
    public class UserRepository : IUserRepository
    {
        private readonly Data.DataContext _context;
        private readonly ILogger<UserRepository> _logger;

        public UserRepository(Data.DataContext context, ILogger<UserRepository> logger
                                                            )
        {
            _context = context;
            _logger = logger;

        }
        public async Task AddAsync(UserEntity userInfo)
        {

            try
            {

                await _context.UserEntity.AddAsync(userInfo);
                await _context.SaveChangesAsync();

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw;
            }
        }

        public async Task<UserEntity> FindAsync(UserEntity userInformation)
        {

            try
            {
                UserEntity userInfo = await _context.UserEntity.FindAsync(userInformation.Id);
                return userInfo;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw;
            }
        }

        public async Task<bool> IsEmailExist(UserEntity userInformation)
        {

            try
            {
                return _context.UserEntity.Any(o => o.Email == userInformation.Email);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw;
            }
        }

        public async Task DeleteAsync()
        {

            try
            {
                _context.Database.ExecuteSqlRaw("DELETE FROM UserInformations");
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw;
            }
        }
    }
}
