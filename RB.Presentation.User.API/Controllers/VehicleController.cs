using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RB.Core.Application.DTO;
using RB.Core.Application.Interface;
using System.Security.Claims;

namespace RB.Presentation.User.API.Controllers
{
    
    [ApiController]
    [Route("api/[controller]")]
    public class VehicleController : ControllerBase
    {
        private readonly IVehicleRegistration _vehicleRegistration;
        public VehicleController(IVehicleRegistration vehicleRegistration)
        {
            _vehicleRegistration = vehicleRegistration;
        }

        [HttpPost]
        [Route("RegisterVehicle")]
        [Authorize(Roles ="User")]
        public IActionResult RegisterVehicle([FromBody]VehicleDTO vehicleDTO)
        {
            var currentUser = GetCurrentUser();
            _vehicleRegistration.RegisterVehicle(vehicleDTO, currentUser.tempId);


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
