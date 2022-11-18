using RB.Core.Application.DTO;
using RB.Core.Application.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using EASendMail;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace RB.Infrastructure.Repository.User
{
    public class EmailService : IEmailService
    {
        private readonly IConfiguration _config;
        public EmailService(IConfiguration config)
        {
            _config = config;
        }
        public void SendMail(EmailDTO emailDTO)
        {
            SmtpMail oMail = new SmtpMail("TryIt");
            oMail.From = emailDTO.From;
            oMail.To = emailDTO.To;
            oMail.Subject = emailDTO.Subject;
            oMail.TextBody = emailDTO.TextBody;
            SmtpServer oServer = new SmtpServer(_config.GetSection("Host").Value);
            oServer.User = _config.GetSection("HostEmail").Value;
            oServer.Password = _config.GetSection("HostPassword").Value;
            oServer.Port = 587;
            oServer.ConnectType = SmtpConnectType.ConnectSSLAuto;

            SmtpClient oSmtp = new SmtpClient();
            oSmtp.SendMail(oServer, oMail); 
        }
    }
}
