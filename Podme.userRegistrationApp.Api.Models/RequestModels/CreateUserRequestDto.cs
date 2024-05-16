namespace Podme.UserRegistrationApp.Api.Models.RequestModels
{
    public class CreateUserRequestDto
    {
        public string UserName { get; set; }
        public DateTime Dob { get; set; }
        public string Email { get; set; }

        public string PhoneNo { get; set; }

        public int GenderId { get; set; }
    }
}
