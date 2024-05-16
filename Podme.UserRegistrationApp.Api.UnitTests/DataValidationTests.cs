using Podme.UserRegistrationApp.Api.Models.RequestModels;
using Podme.UserRegistrationApp.Api.Validators;

namespace Podme.UserRegistrationApp.Api.UnitTests
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

        [Fact]
        public void CreateUserRequestValidator_InValidData()
        {

            //Arrange
            var userInfo = new CreateUserRequestDto
            {
                UserName = "A",
                Dob = DateTime.Today,
                Email = "ad@a.com",
                PhoneNo = "123456789",
                GenderId = 1
            };

            //Act
            CreateUserRequestValidator validator = new CreateUserRequestValidator();
            var validationResult = validator.Validate(userInfo);

            //Assert
            Assert.False(validationResult.IsValid);

        }
    }
}