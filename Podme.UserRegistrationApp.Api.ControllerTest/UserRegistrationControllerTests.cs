using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using Podme.UserRegistrationApp.Api.Configurations;
using Podme.UserRegistrationApp.Api.Controllers;
using Podme.UserRegistrationApp.Api.Entitites;
using Podme.UserRegistrationApp.Api.Models.RequestModels;
using Podme.UserRegistrationApp.Api.Models.ResponseModels;
using Podme.UserRegistrationApp.Api.Repositories.Contracts;

namespace Podme.UserRegistrationApp.Api.ControllerTests
{
    public class UserRegistrationControllerTests
    {
        UserRegistrationController _controller;
        private static IMapper _mapper;

        public UserRegistrationControllerTests()
        {
            if (_mapper == null)
            {
                var mappingConfig = new MapperConfiguration(mc =>
                {
                    mc.AddProfile(new MappingConfig());
                });
                IMapper mapper = mappingConfig.CreateMapper();
                _mapper = mapper;
            }
        }
        [Fact]
        public void RegisterUser_ValidTest()
        {
            var userInfo = new CreateUserRequestDto
            {
                UserName = "user",
                Dob = DateTime.Today,
                Email = "av@a.com",
                PhoneNo = "123456789",
                GenderId = 1
            };
            var userEntity = new UserEntity();

            var loggerMock = new Mock<ILogger<UserRegistrationController>>();
            var repoMock = new Mock<IUserRepository>();
          
            repoMock.Setup(x => x.AddAsync(userEntity)).Returns(Task.CompletedTask);

            _controller = new UserRegistrationController(repoMock.Object, _mapper, loggerMock.Object);
            var result = _controller.RegisterUser(userInfo);

            Assert.IsType<OkObjectResult>(result.Result);

            var okResult = result.Result as OkObjectResult;

            Assert.IsType<ApiResponseDto<CreateUserResponseDto>>(okResult.Value);

            var obj = okResult.Value as ApiResponseDto<CreateUserResponseDto>;
            Assert.NotNull(obj);
        }

        [Fact]
        public void GetRegisteredUser_ValidTest()
        {
            var getUserInfo = new GetUserRequestDto
            {
              Id = 2
            };
            var userEntity = new UserEntity()
            {
                Id = 2,
                UserName = "John Doe",
                Email = "J.D@gmail.com",
                PhoneNo = "123456789",
                GenderId = 1
            };

            var loggerMock = new Mock<ILogger<UserRegistrationController>>();
            var repoMock = new Mock<IUserRepository>();
            var userInfo = new UserEntity();

            repoMock.Setup(x => x.FindAsync(It.IsAny<UserEntity>())).Returns(Task.FromResult(userEntity));

            _controller = new UserRegistrationController(repoMock.Object, _mapper, loggerMock.Object);
            var result = _controller.GetRegisteredUser(getUserInfo);

            Assert.IsType<OkObjectResult>(result.Result);

            var okResult = result.Result as OkObjectResult;

            Assert.IsType<ApiResponseDto<GetUserResponseDto>>(okResult.Value);

            var obj = okResult.Value as ApiResponseDto<GetUserResponseDto>;
            Assert.NotNull(obj);
        }

       
    }
}