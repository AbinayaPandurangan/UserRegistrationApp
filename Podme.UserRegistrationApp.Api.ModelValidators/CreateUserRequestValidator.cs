using FluentValidation;
using Podme.UserRegistrationApp.Api.Models.RequestModels;

namespace Podme.UserRegistrationApp.Api.Validators
{
    public class CreateUserRequestValidator : AbstractValidator<CreateUserRequestDto>
    {
        public CreateUserRequestValidator()
        {
            RuleFor(x => x.UserName ).NotNull().NotEmpty();
            RuleFor(x => x.UserName).Matches("^[a-zA-Z]*$").WithMessage("Invalid User name");
            RuleFor(x => x.UserName).MinimumLength(2).WithMessage("User Name should be atleast 2 characters long");

            RuleFor(x => x.Email).NotEmpty().NotNull();
            RuleFor(x => x.Email).EmailAddress().WithMessage("Invalid EMail Address");

            RuleFor(x => x.GenderId).NotEmpty().NotNull();
            RuleFor(x => x.GenderId).InclusiveBetween(1, 4).WithMessage("Gender Id should be withing 1 - 4");

            RuleFor(x => x.PhoneNo).NotEmpty().NotNull();
            RuleFor(x => x.PhoneNo).Length(9).WithMessage("Phone No. should be atleast 9 characters long");
            RuleFor(x => x.PhoneNo).Matches("^\\d{9}$").WithMessage("Invalid Phone number");

            RuleFor(x => x.Dob).NotNull().NotEmpty();
            RuleFor(x => x.Dob).Must(BeAValidAge).WithMessage("Invalid Date of Birth");
        }

        protected bool BeAValidAge(DateTime date)
        {
            int currentYear = DateTime.Now.Year;
            int dobYear = date.Year;

            if (dobYear <= currentYear && dobYear > (currentYear - 120))
            {
                return true;
            }

            return false;
        }
    }
}
