using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RB.Core.Application.DTO;
using RB.Core.Application.Interface;
using System.Security.Claims;

namespace RB.Presentation.User.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HostRideController : ControllerBase
    {
        private readonly IHostRideService _hostRideService;
        public HostRideController(IHostRideService hostRideService)
        {
            _hostRideService = hostRideService;
        }
        [HttpPost]
        [Authorize(Roles = "User")]
        public IActionResult HostARide([FromBody] HostedRidesDTO HostedRidesDTO)
        {
            var currentUser = GetCurrentUser();
            _hostRideService.HostRide(HostedRidesDTO, currentUser.tempId);


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
