using Microsoft.AspNetCore.Mvc;
using Podme.UserRegistrationApp.Api.Entitites;
using Podme.UserRegistrationApp.Utils;
using Podme.UserRegistrationApp.Api.Models.RequestModels;
using Podme.UserRegistrationApp.Api.Models.ResponseModels;
using Podme.UserRegistrationApp.Api.Repositories.Contracts;
using AutoMapper;

namespace Podme.UserRegistrationApp.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserRegistrationController : ControllerBase
    {
        private readonly IUserRepository _userInformationRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<UserRegistrationController> _logger;

        public UserRegistrationController(IUserRepository userRepo, IMapper mapper, ILogger<UserRegistrationController> logger)
        {
            _userInformationRepository = userRepo;
            _mapper = mapper;
            _logger = logger;
        }

        [HttpPost("RegisterUser")]
        //[ProducesResponseType(StatusCodes.Status200OK)]
        // [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> RegisterUser(CreateUserRequestDto userRequestDto)
        {
            try
            {
                var validationResult = ValidatorUtils.CreateUserRequestIsValid(userRequestDto);
                if (!validationResult.IsValid)
                {
                    return BadRequest(validationResult.Errors);
                }

                var userEntity = _mapper.Map<UserEntity>(userRequestDto);

                var doesUserExist = await _userInformationRepository.IsEmailExist(userEntity);

                if (doesUserExist)
                {
                    return BadRequest(new ApiResponseDto<string>()
                    {
                        Data = "Email Id is already registered.",
                        isSuccess = false
                    }); 

                }

                await _userInformationRepository.AddAsync(userEntity);


                var userResponseDto = _mapper.Map<CreateUserResponseDto>(userEntity);

                var apiResponse = ResponseUtils.GetResponse(userResponseDto);

                return Ok(apiResponse);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                return BadRequest(new ApiResponseDto<string>()
                {
                    Data = "Internal Server Error",
                    isSuccess = false
                }); 
            }

        }

        [HttpPost("GetRegisteredUser")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetRegisteredUser(GetUserRequestDto userRequestDto)
        {
            try
            {

                var userEntity = _mapper.Map<UserEntity>(userRequestDto);

                var userInfo = await _userInformationRepository.FindAsync(userEntity);

                if (userInfo is null)
                {
                    return NotFound($"User Doesn't Exists for ID: {userRequestDto.Id}.");
                }

                var userResponseDto = _mapper.Map<GetUserResponseDto>(userInfo);

                var apiResponse = ResponseUtils.GetResponse(userResponseDto);

                return Ok(apiResponse);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                return BadRequest(new ApiResponseDto<string>()
                {
                    Data = "Internal Server Error",
                    isSuccess = false
                }); 
            }
        }
    }
}