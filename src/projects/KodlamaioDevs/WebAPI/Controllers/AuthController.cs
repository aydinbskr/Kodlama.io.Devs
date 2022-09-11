using Application.Features.SystemUsers.Commands.UserRegister;
using Application.Features.SystemUsers.Queries.UserLogin;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : BaseController
    {
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] UserRegisterCommand createSystemUserCommand)
        {
            var result = await Mediator.Send(createSystemUserCommand);
            return Ok(result);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] UserLoginQuery userLoginQuery)
        {
            var result = await Mediator.Send(userLoginQuery);
            return Ok(result);
        }
    }
}
