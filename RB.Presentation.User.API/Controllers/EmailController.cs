using EASendMail;
using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using MimeKit.Text;
using RB.Core.Application.DTO;
using RB.Core.Application.Interface;
using SmtpClient = EASendMail.SmtpClient;

namespace RB.Presentation.User.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmailController : ControllerBase
    {
        private readonly IEmailService _emailService;
        public EmailController(IEmailService emailService)
        {
            _emailService = emailService;
        }

        [HttpPost]
        public IActionResult SendEmail(EmailDTO emailDTO)
        {
            _emailService.SendMail(emailDTO);
            return Ok();
        }
    }
}
