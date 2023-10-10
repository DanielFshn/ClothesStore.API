using AutoMapper;
using ClothesStrore.Application.Common.Exceptions;
using ClothesStrore.Application.Context;
using ClothesStrore.Application.Product;
using ClothesStrore.Application.Product.GetById;
using ClothesStrore.Application.Product.GetProducts;
using ClothesStrore.Application.ProductsRating.GetProductRatings;
using Microsoft.EntityFrameworkCore;

namespace ClothesStore.Infrastructure.Products
{
    internal class ProductService : IProductService
    {
        private readonly IMyDbContext _context;
        private readonly IMapper _mapper;

        public ProductService(IMyDbContext context, IMapper mapper) =>
            (_mapper, _context) = (mapper, context);
        public async Task<GetProductByIdResponse> GetProductByIdAsync(GetProductByIdRequest request, CancellationToken cancellationToken)
        {
            var product = await _context.Products
            .Where(p => p.IsRelease != false && p.Id != null)
            .FirstOrDefaultAsync(p => p.Id == request.id.ToString());


            if (product == null)
                throw new NotFoundException("Product not found!");
            var productDTO = _mapper.Map<GetProductByIdResponse>(product);
            return productDTO;
        }

        public Task<List<GetAllProductsResponse>> GetProducts(GetAllProductsRequest request, CancellationToken cancellationToken)
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
            return query.ToListAsync();
        }
    }
}
