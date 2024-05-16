using Podme.UserRegistrationApp.Api.Models.RequestModels;
using Podme.UserRegistrationApp.Api.Validators;
using Xunit;

namespace Podme.UserRegistrationApp.Api.Tests
{
    public class DataValidationTests
    {
        [Fact]
        public void CreateUserRequestValidator_ValidData()
        {
            //Arrange
            var userInfo = new CreateUserRequestDto
            {
                UserName = "NewUser",
                Dob = DateTime.Today,
                Email = "ab@a.com",
                PhoneNo = "123456789",
                GenderId = 1
            };

            //Act
            CreateUserRequestValidator validator = new CreateUserRequestValidator();
            var validationResult = validator.Validate(userInfo);

            //Assert
            Assert.True(validationResult.IsValid);

        }
    }
}