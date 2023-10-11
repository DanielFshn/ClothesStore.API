namespace ClothesStrore.Application.User.ResetPasswordWithToken;

public class ResetPasswordCommandHandler : IRequestHandler<ResetPasswordRequest, string>
{
    private readonly IUserService _service;

    public ResetPasswordCommandHandler(IUserService service) =>
        _service = service;


    public async Task<string> Handle(ResetPasswordRequest request, CancellationToken cancellationToken) =>
        await _service.ResetPassowrdWithTokenAsync(request, cancellationToken);
}
