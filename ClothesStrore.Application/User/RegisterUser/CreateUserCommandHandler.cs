namespace ClothesStrore.Application.User.CreaeteUser;

public class CreateUserCommandHandler : IRequestHandler<CreateUserRequest, string>
{
    private readonly IUserService _service;
    public CreateUserCommandHandler(IUserService service) =>
        _service = service;


    public async Task<string> Handle(CreateUserRequest request, CancellationToken cancellationToken) =>
        await _service.CreateAsync(request, cancellationToken);
   
}
