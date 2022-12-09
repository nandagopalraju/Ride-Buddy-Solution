using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RB.Core.Application.DTO;
using RB.Core.Application.Interface;

namespace RB.Presentation.User.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly ILoginService _loginService;
        public LoginController(ILoginService loginService)
        {
            _loginService = loginService;

        }
        [HttpPost]
        public IActionResult Login(LoginDTO loginDTO)
        {
            var result = _loginService.Login(loginDTO);
            if(result == "user not found")
            {
                return BadRequest("user not found");
            }
            else if(result == "wrong password")
            {
                return BadRequest("wrong password");
            }
            return Ok(result);
        }

    }
}
