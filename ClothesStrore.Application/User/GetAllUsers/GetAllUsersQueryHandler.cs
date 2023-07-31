using AutoMapper.QueryableExtensions;
using ClothesStrore.Application.Context;
using Microsoft.EntityFrameworkCore;

namespace ClothesStrore.Application.User.GetAllUsers
{
    public class GetAllUsersQueryHandler : IRequestHandler<GetAllUsersRequest, List<GetAllUsersResponse>>
    {
        public IMapper _mapper { get; }
        public IMyDbContext _context { get; }
        public UserManager<IdentityUser> _userManager { get; }

        public GetAllUsersQueryHandler(IMapper mapper, IMyDbContext context, UserManager<IdentityUser> userManager)
        {
            _mapper = mapper;
            _context = context;
            _userManager = userManager;
        }


        public Task<List<GetAllUsersResponse>> Handle(GetAllUsersRequest request, CancellationToken cancellationToken)
        {
            return _userManager.Users.ProjectTo<GetAllUsersResponse>(_mapper.ConfigurationProvider).ToListAsync();
        }
    }
}
