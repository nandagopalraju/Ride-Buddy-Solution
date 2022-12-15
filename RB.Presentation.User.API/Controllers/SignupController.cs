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
        public static IWebHostEnvironment _environment;
        private readonly ISignupConfirmation _signupConfirmation;

        public SignupController(ISignupFunctions signUpContext, IWebHostEnvironment environment, ISignupConfirmation signupConfirmation)
        {
            _signUpContext = signUpContext;
            _environment = environment;
            _signupConfirmation = signupConfirmation;
        }

        // public static Signup signup = new Signup();

        [HttpPost]
        [Route("Signup")]
        public IActionResult SignUp(SignupDTO signupDTO)
        {
            HttpContext.Session.SetString("email", signupDTO.Email);

            if (!ModelState.IsValid)
            {
                return BadRequest("not a valid request");
            } 
            _signUpContext.SignUp(signupDTO);
            return Ok();
        }

        [HttpPost]
        [Route("Confirmmail")]
        public IActionResult ConfirmMail(SignupConfirmationDTO confirmationDTO)
        {
            //var email = HttpContext.Session.GetString("email");
            //if(email==confirmationDTO.Email)
            {
                _signupConfirmation.Register(confirmationDTO.Email);

            }
            return Ok();
        }

 

        [HttpGet]
        [Route("Userdetails")]
        public IActionResult UserDetails()
        {
            if(!ModelState.IsValid)
            {
                return BadRequest("not a valid request");
            }
            var data = _signUpContext.UserDetails();
            return Ok(data);

        }

    }
}
