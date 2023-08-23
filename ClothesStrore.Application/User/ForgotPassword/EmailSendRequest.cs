namespace ClothesStrore.Application.User.ForgotPassword;

public class EmailSendRequest : IRequest<string>
{
    public string Email { get; set; }
}
