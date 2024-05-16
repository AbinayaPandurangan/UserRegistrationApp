namespace Podme.UserRegistrationApp.Api.Models.ResponseModels
{
    public class ApiResponseDto<T>
    {
        public T Data { get; set; }
        public bool isSuccess { get; set; }
    }
}
