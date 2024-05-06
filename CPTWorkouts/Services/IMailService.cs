using CPTWorkouts.Models;

namespace CPTWorkouts.Services
{
    public interface IMailService
    {
        Task SendEmailAsync(MailRequest mailRequest);
    }
}
