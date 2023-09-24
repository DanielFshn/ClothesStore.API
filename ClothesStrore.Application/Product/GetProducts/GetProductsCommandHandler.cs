using ClothesStrore.Application.Context;
using Microsoft.EntityFrameworkCore;

namespace ClothesStrore.Application.Product.GetProducts;

public class GetProductsCommandHandler : IRequestHandler<GetAllProductsRequest, List<GetAllProductsResponse>>
{
    public IMapper _mapper { get; }
    public IMyDbContext _context { get; }
    public UserManager<IdentityUser> _userManage { get; }

    public GetProductsCommandHandler(IMapper mapper, IMyDbContext context, UserManager<IdentityUser> userManager)
    {
        _mapper = mapper;
        _context = context;
        _userManage = userManager;
    }



    public async Task<List<GetAllProductsResponse>> Handle(GetAllProductsRequest request, CancellationToken cancellationToken)
    {
        var query = (from p in _context.Products
                     join c in _context.Categories on p.CategoryId equals c.Id
                     join s in _context.Sizes on p.SizeId equals s.Id
                     join g in _context.Genders on p.GenderId equals g.Id
                     where p.IsRelease
                     select new GetAllProductsResponse
                     {
                         CategoryName = c.CategoryName,
                         Description = p.Description,
                         Id = p.Id,
                         GenderName = g.GenderName,
                         ImageUrl = p.ImageUrl,
                         Name = p.Name,
                         SizeName = s.Name,
                         Price = p.Price,
                         RatingNumber = !string.IsNullOrEmpty(request.UserId) ? (from pr in _context.ProductRatings
                                         where pr.ProductId == p.Id && pr.UserId == request.UserId
                                         select (int?)pr.RatingNumber)
                                    .FirstOrDefault() ?? 0 : 0,
                     });
        if (!string.IsNullOrEmpty(request.Id))
            query = query.Where(p => p.Id == request.Id);
        else
        {
            if (!string.IsNullOrEmpty(request.Category))
                query = query.Where(p => p.CategoryName == request.Category);
            if (!string.IsNullOrEmpty(request.Size))
                query = query.Where(p => p.SizeName == request.Size);
            if (!string.IsNullOrEmpty(request.Gender))
                query = query.Where(p => p.GenderName == request.Gender);
        }
        return await query.ToListAsync();
    }
}
