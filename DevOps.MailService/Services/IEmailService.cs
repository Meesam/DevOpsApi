using DevOps.MailService.Models;

namespace DevOps.MailService.Services
{
    public interface IEmailService
    {
       void SendEmail(Message message);
    }
}
