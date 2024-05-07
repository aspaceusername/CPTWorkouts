using CPTWorkouts.Models;

namespace CPTWorkouts.Services.Mail
{
    public interface IMailService
    {
        Task SendEmailAsync(MailRequest mailRequest);
    }
}
