using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RB.Core.Application.DTO;
using RB.Core.Application.Interface;
using RB.Infrastructure.Repository.User;
using System.Security.Claims;

namespace RB.Presentation.User.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JoinRideController : ControllerBase
    {
        private readonly IJoinRideService _joinRideService;
        public JoinRideController(IJoinRideService joinRideService)
        {
            _joinRideService = joinRideService;
        }
        [HttpPost]
        [Authorize(Roles ="User")]
        public IActionResult JoinRide([FromBody]JoinRideDTO joinRideDTO)
        {
            var currentUser = GetCurrentUser();
            _joinRideService.JoinRide(joinRideDTO, currentUser.tempId);


            return Ok();
        }
        private TempUserDTO GetCurrentUser()
        {
            var temp = new TempUserDTO();
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            if (identity != null)
            {
                var userClaims = identity.Claims;
                return new TempUserDTO
                {
                    Name = userClaims.FirstOrDefault(o => o.Type == ClaimTypes.Name)?.Value,
                    Email = userClaims.FirstOrDefault(o => o.Type == ClaimTypes.Email)?.Value,
                    Role = userClaims.FirstOrDefault(o => o.Type == ClaimTypes.Role)?.Value,
                    tempId = int.Parse(userClaims.FirstOrDefault(o => o.Type == "Id")?.Value)

                };
            }

            return temp;
        }
    }
}
