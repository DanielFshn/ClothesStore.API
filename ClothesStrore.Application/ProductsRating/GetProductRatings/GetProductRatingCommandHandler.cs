using ClothesStrore.Application.Context;
using Microsoft.EntityFrameworkCore;

namespace ClothesStrore.Application.ProductsRating.GetProductRatings;

public class GetProductRatingCommandHandler : IRequestHandler<GetAllProductRatingRequest, List<GetAllProductRatingResponse>>
{

    public IMapper _mapper { get; }
    public IMyDbContext _context { get; }
    public UserManager<IdentityUser> _userManager { get; }

    public GetProductRatingCommandHandler(IMapper mapper, IMyDbContext context, UserManager<IdentityUser> userManager)
    {
        _mapper = mapper;
        _context = context;
        _userManager = userManager;
    }


    public async Task<List<GetAllProductRatingResponse>> Handle(GetAllProductRatingRequest request, CancellationToken cancellationToken)
    {
        var users = await _userManager.Users.ToListAsync(cancellationToken);
        var response = (from pr in _context.ProductRatings
                        join p in _context.Products on pr.ProductId equals p.Id
                        where pr.DeletedOn == null
                        select new
                        {
                            pr,
                            p
                        }).AsEnumerable()
                .Select(item => _mapper.Map<GetAllProductRatingResponse>(item.pr))
                .ToList();
        return response;
    }
}
