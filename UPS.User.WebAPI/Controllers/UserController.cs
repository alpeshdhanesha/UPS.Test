using Microsoft.AspNetCore.Mvc;
using UPS.Application.Contract;
using USP.Model;

namespace UPS.User.WebAPI.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("public-api/v{version:apiVersion}")]
    [Authorize()]
    public class UserController : BaseAPIController
    {

        private readonly ILogger<UserController> _logger;
        private readonly IUserService _userService;

        public UserController(ILogger<UserController> logger, IUserService userService)
        {
            _logger = logger;
            _userService = userService;
        }


        [HttpGet]
        [Route("users")]
        public async Task<IActionResult> Get()
        {
            try
            {
                var result = await _userService.GetAllUsersAsync();
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return NotFound("Unable to retrieve a record.");
            }
        }

        [HttpGet]
        [Route("users/{id:int}")]
        public IActionResult Get(int id)
        {
            try
            {
                var result = _userService.GetUser(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return NotFound("Unable to retrieve a record.");
            }
        }

        [HttpGet]
        [Route("users/{first_name}")]
        public IActionResult Get([FromBody] string first_name)
        {
            try
            {
                var result = _userService.GetUser(first_name);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return NotFound("Unable to retrieve a record.");
            }
        }

        [HttpPost]
        [Route("users")]
        public async Task<IActionResult> AddUser(UserDto user)
        {
            try
            {
                var result = await _userService.AddUserAsync(user);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return NotFound("Unable to add a record.");
            }
        }

        [HttpPut]
        [Route("users/{id}")]
        public IActionResult UpdateUser(int id, UserDto user)
        {
            try
            {
                user.UserId = id;
                var result = _userService.UpdateUser(user);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return NotFound("Unable to update a record.");
            }
        }

        [HttpDelete]
        [Route("users")]
        public IActionResult Delete([FromBody] int id)
        {
            try
            {
                var result = _userService.DeleteUser(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return NotFound("Unable to delete a record.");
            }
        }
    }
}