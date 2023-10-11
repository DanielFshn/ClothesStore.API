namespace ClothesStrore.Application.User.LoginUser
{
    public class LogInUserCommandHandler : IRequestHandler<LoginUserRequest, LoginUserResponse>
    {
        private readonly IUserService _service;
        public LogInUserCommandHandler(IUserService service) =>
            _service = service;

        public async Task<LoginUserResponse> Handle(LoginUserRequest request, CancellationToken cancellationToken) =>
            await _service.LogInAsync(request, cancellationToken);
    }
}
