namespace ClothesStrore.Application.User.ForgotPassword;

public class ForgotPasswordCommandHandler : IRequestHandler<EmailSendRequest, string>
{
    private readonly IUserService _service;
    public ForgotPasswordCommandHandler(IUserService service) =>
        _service = service;

    public async Task<string> Handle(EmailSendRequest request, CancellationToken cancellationToken) =>
        await _service.ForgotPasswordAsync(request, cancellationToken);
}
