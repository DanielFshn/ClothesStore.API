using ClothesStrore.Application.Common.Exceptions;
using ClothesStrore.Application.Context;
using Microsoft.EntityFrameworkCore;

namespace ClothesStrore.Application.ProductsRating.InsertProductRatings;

public class CreateProductRaringCommandHandler : IRequestHandler<CreateProductRatingRequest, string>
{
    public IMapper _mapper { get; }
    public IMyDbContext _context { get; }
    public UserManager<IdentityUser> _userManager { get; }

    public CreateProductRaringCommandHandler(IMapper mapper, IMyDbContext context, UserManager<IdentityUser> userManger)
    {
        _mapper = mapper;
        _context = context;
        _userManager = userManger;
    }

    public async Task<string> Handle(CreateProductRatingRequest request, CancellationToken cancellationToken)
    {
        if (await _context.Products.AnyAsync(x => x.Id == request.ProductId))
        {
            var user = await _userManager.FindByIdAsync(request.UserId);
            if (user == null)
                throw new NotFoundException("There is no product or user with the specified criteria.");
            else
            {
                var productRating = _mapper.Map<ProductRating>(request);
                _context.ProductRatings.Add(productRating);
                await _context.SaveToDbAsync();
                return JsonConvert.SerializeObject(new { Message = "Product rating is added succesfully" });
            }

        }
        return JsonConvert.SerializeObject(new { Message = "Error accured!" });

    }
}
