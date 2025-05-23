namespace ReadHaven.Application.Contracts.Infrastructure
{
    public interface IEmailService
    {
        Task SendEmailAsync(EmailMessage message);
    }
}
