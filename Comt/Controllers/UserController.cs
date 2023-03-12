using DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ServicesInterfaces;

namespace Comt.Controllers
{
    [ApiController]
    [Route("UserController")]
    public class UserController : Controller
    {
        public IUserService _userService;
        public UserController(IUserService userService) {
            _userService = userService;
        }



        [HttpPost]
        [AllowAnonymous]
        [Route("login")]
        public async Task<ActionResult<bool>> Login([FromBody] LoginDto user)
        {
            var result = await _userService.Login(new UserDto(user));
            return Ok(result);
        }

    }
}
