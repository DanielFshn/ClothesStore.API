namespace ClothesStrore.Application.User.ChangePassword
{
    public class ChangePasswordCommandHandler : IRequestHandler<ChangePasswordRequest, string>
    {
        private readonly IUserService _service;
        public ChangePasswordCommandHandler(IUserService service) =>
            _service = service;


        public async Task<string> Handle(ChangePasswordRequest request, CancellationToken cancellationToken) =>
            await _service.ChangePasswordAsync(request, cancellationToken);
        
           
    }
}
