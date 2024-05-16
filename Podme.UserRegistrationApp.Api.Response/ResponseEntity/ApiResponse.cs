namespace Podme.UserRegistrationApp.Api.ResponseEntity
{
    public class ApiResponse<T>
    {
        public  T Data { get; set; }
        public bool isSuccess { get; set; }
    }
}
