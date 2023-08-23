using ClothesStrore.Application.User.ForgotPassword;

namespace ClothesStrore.Application.Common.Email;

public interface IEmailService
{
    Task SendEmail(EmailSendResponse emailSendRequest);
}
