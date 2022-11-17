using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using RB.Core.Application.DTO;
using RB.Core.Application.Interface;
using RB.Core.Domain.Models;
using RB.Infrastructure.Repository;
using RB.Infrastructure.Repository.Services.User.Interface;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;

namespace RB.Presentation.User.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SignupController : ControllerBase
    {
        private readonly ISignupFunctions _signUpContext;
        private readonly ISignupValidations _signupValidations;
        private IConfiguration _config;

        public SignupController(ISignupFunctions signUpContext, IConfiguration config, ISignupValidations signupValidations)
        {
            _signUpContext = signUpContext;
            _config = config;
            _signupValidations = signupValidations;
        }

        public static Signup signup = new Signup();

        [HttpPost]
        public IActionResult SignUp(SignupDTO signupDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("not a valid request");
            }
            _signUpContext.SignUp(signupDTO);
            return Ok();
        }

    }
}
