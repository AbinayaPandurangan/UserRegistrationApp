using Podme.UserRegistrationApp.Api.Entitites;

namespace Podme.UserRegistrationApp.Api.Repositories.Contracts
{
    public interface IUserRepository
    {
        Task AddAsync(UserEntity userEntity);
        Task<UserEntity> FindAsync(UserEntity userEntity);

        Task<bool> IsEmailExist(UserEntity userEntity);
        Task DeleteAsync();
    }
}
