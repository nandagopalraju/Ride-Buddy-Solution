using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RB.Core.Application.DTO;
using RB.Core.Application.Interface;

namespace RB.Presentation.User.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HostAcceptController : ControllerBase
    {

        private readonly IHostAcceptService _hostAcceptService;
        public HostAcceptController(IHostAcceptService hostAcceptService)
        {
            _hostAcceptService = hostAcceptService;
        }


        [HttpPost]
        [Authorize(Roles = "User")]
        public IActionResult HostAccept(HostAcceptDTO hostAcceptDTO)
        {
            _hostAcceptService.HostAccept(hostAcceptDTO.Id);
            return Ok();

        }
    }
}
