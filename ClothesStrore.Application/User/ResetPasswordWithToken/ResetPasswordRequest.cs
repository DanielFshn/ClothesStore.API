namespace ClothesStrore.Application.User.ResetPasswordWithToken;

public class ResetPasswordRequest : IRequest<string>
{
    public string Email { get; set; }
    public string Token { get; set; }
    public string NewPassword { get; set; }
    public string RepeatNewPass { get; set; }
}
