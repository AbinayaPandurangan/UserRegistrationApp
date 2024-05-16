namespace Podme.UserRegistrationApp.Api.Models.ResponseModels
{
    public class GetUserResponseDto
    {
        public string UserName { get; set; }
        public DateTime Dob { get; set; }
        public string Email { get; set; }

        public string PhoneNo { get; set; }

        public int GenderId { get; set; }

        public string GenderName
        {
            get
            {
                string result = GenderId switch
                {
                    1 => "Male",
                    2 => "Female",
                    3 => "Non-Binary",
                    4 => "Not-Specified"
                };
                return result;
            }

        }
    }
}
