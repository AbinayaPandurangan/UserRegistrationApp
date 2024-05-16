using Podme.UserRegistrationApp.Api.Models.ResponseModels;

namespace Podme.UserRegistrationApp.Utils
{
    public static class ResponseUtils {

        public static ApiResponseDto<T> GetResponse<T>(T data)
        {
            return new()
            {
                Data = data,
                isSuccess = true,
            };
        }

    }
   

}