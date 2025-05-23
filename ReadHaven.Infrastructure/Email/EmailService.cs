using System.Net;
using System.Net.Mail;
using Microsoft.Extensions.Configuration;
using ReadHaven.Application.Contracts.Infrastructure;

namespace ReadHaven.Infrastructure.Email
{
    public class EmailService : IEmailService
    {
        private readonly IConfiguration _configuration;
        private readonly SmtpClient _smtpClient;
        private readonly string _from;

        public EmailService(IConfiguration configuration)
        {
            _configuration = configuration;

            var host = _configuration["EmailSettings:Server"];
            var port = int.Parse(_configuration["EmailSettings:Port"]);
            var username = _configuration["EmailSettings:Email"];
            var password = _configuration["EmailSettings:Password"];
            _from = configuration["EmailSettings:Email"];

            _smtpClient = new SmtpClient(host, port)
            {
                Credentials = new NetworkCredential(username, password),
                EnableSsl = true
            };
        }

        public async Task SendEmailAsync(EmailMessage message)
        {
            var mail = new MailMessage(_from, message.To, message.Subject, message.Body)
            {
                IsBodyHtml = message.IsHtml
            };

            await _smtpClient.SendMailAsync(mail);
        }
    }
}
