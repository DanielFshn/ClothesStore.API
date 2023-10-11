namespace ClothesStrore.Application.User.GetAllUsers
{
    public class GetAllUsersQueryHandler : IRequestHandler<GetAllUsersRequest, List<GetAllUsersResponse>>
    {
        private readonly IUserService _service;

        public GetAllUsersQueryHandler(IUserService service) =>
            _service = service;


        public async Task<List<GetAllUsersResponse>> Handle(GetAllUsersRequest request, CancellationToken cancellationToken) =>
            await _service.GetUsersAsync(request, cancellationToken);
        
    }
}
