using Podme.UserRegistrationApp.Api.Models.RequestModels;
using Podme.UserRegistrationApp.Api.Models.ValidationResultModels;
using Podme.UserRegistrationApp.Api.Validators;
using System.ComponentModel.DataAnnotations;

namespace Podme.UserRegistrationApp.Utils
{
    public static class ValidatorUtils
    {
        public static Result CreateUserRequestIsValid(CreateUserRequestDto userRequestDto)
        {
            CreateUserRequestValidator validator = new();

            var ValidationResult = validator.Validate(userRequestDto);

            Result result = new()
            {
                IsValid = ValidationResult.IsValid,
                Errors = ValidationResult.ToString("~")
            };
            

            return result;
        }
    }
}
