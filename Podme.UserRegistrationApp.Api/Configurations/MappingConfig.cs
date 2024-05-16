using AutoMapper;
using Podme.UserRegistrationApp.Api.Entitites;
using Podme.UserRegistrationApp.Api.Models.RequestModels;
using Podme.UserRegistrationApp.Api.Models.ResponseModels;

namespace Podme.UserRegistrationApp.Api.Configurations
{
    public class MappingConfig :Profile
    {
        public MappingConfig()
        {
            CreateMap<UserEntity, CreateUserRequestDto>().ReverseMap();
            CreateMap<UserEntity, CreateUserResponseDto>().ReverseMap();
            
            CreateMap<UserEntity, GetUserRequestDto>().ReverseMap();
            CreateMap<UserEntity, GetUserResponseDto>().ReverseMap();
        }
    }
}
