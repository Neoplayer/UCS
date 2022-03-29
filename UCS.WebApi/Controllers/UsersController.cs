using Microsoft.AspNetCore.Mvc;
using UCS.WebApi.Helpers;
using UCS.WebApi.Models.User;
using UCS.WebApi.Services;

namespace UCS.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        private IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }


        // [HttpPost("Register")]
        // public IActionResult Register(RegisterRequest model)
        // {
        //     var response = _userService.RegisterUser(model);
        //
        //     if (response == false)
        //         return BadRequest(new { message = "Registration error" });
        //
        //     var result = _userService.Authenticate(new AuthenticateRequest()
        //     {
        //         Username = model.Username,
        //         Password = model.Password
        //     });
        //
        //     return Ok(new { status = response, user = result });
        // }

        [HttpPost("Authenticate")]
        public IActionResult Authenticate(AuthenticateRequest model)
        {
            var response = _userService.Authenticate(model);

            if (response == null)
                return BadRequest(new { message = "Username or password is incorrect" });

            return Ok(response);
        }

        [Authorize]
        [HttpGet("GetUser")]
        public IActionResult GetUserData()
        {
            var user = HttpContext.Items["User"];

            if (user == null)
            {
                return (BadRequest("Auth error!"));
            }
            return Ok(user);
        }
    }
}
