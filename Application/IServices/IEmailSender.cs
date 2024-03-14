using Application.DTOs.Users;

namespace Application.IServices
{

    public interface IEmailSender
    {
        void SendEmail(Message message);
        Task<bool> SendEmailAsync(Message message);
    }

}
