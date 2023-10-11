using AutoMapper;
using ClothesStore.Domain.Entities;
using ClothesStrore.Application.Common.Exceptions;
using ClothesStrore.Application.Context;
using ClothesStrore.Application.ProductsRating;
using ClothesStrore.Application.ProductsRating.GetProductRatings;
using ClothesStrore.Application.ProductsRating.InsertProductRatings;
using ClothesStrore.Application.ProductsRating.UpdateProductRating;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace ClothesStore.Infrastructure.ProductRatings;

internal class ProductRatingService : IProductRating
{

    public IMapper _mapper { get; }
    public IMyDbContext _context { get; }
    public UserManager<IdentityUser> _userManager { get; }

    public ProductRatingService(IMapper mapper, IMyDbContext context, UserManager<IdentityUser> userManager) =>
        (_mapper, _context, _userManager) = (mapper, context, userManager);


    public async Task<string> CreateAsync(CreateProductRatingRequest request, CancellationToken cancellationToken)
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

    public async Task<List<GetAllProductRatingResponse>> GetAsync(GetAllProductRatingRequest request, CancellationToken cancellationToken)
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

    public async Task<string> UpdateAsync(UpdateProductRatingCommand request, CancellationToken cancellationToken)
    {
        var productRating = await _context.ProductRatings.FirstOrDefaultAsync(x => x.ProductId == request.ProductId && x.UserId == request.updateProdutRatingDto.UserId);
        if (productRating == null)
            return JsonConvert.SerializeObject(new { Message = "Not found rating for this product!" });
        _mapper.Map(request, productRating);
        await _context.SaveToDbAsync();
        return JsonConvert.SerializeObject(new { Message = "Product Raitng is updated succesfully" });
    }
}
