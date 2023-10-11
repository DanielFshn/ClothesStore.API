using AutoMapper;
using ClothesStrore.Application.Common.Exceptions;
using ClothesStrore.Application.Context;
using ClothesStrore.Application.Product;
using ClothesStrore.Application.Product.GetById;
using ClothesStrore.Application.Product.GetProducts;
using ClothesStrore.Application.Product.InsertProduct;
using ClothesStrore.Application.Product.UpdateProdduct;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace ClothesStore.Infrastructure.Products
{
    internal class ProductService : IProductService
    {
        private readonly IMyDbContext _context;
        private readonly IMapper _mapper;

        public ProductService(IMyDbContext context, IMapper mapper) =>
            (_mapper, _context) = (mapper, context);

        public async Task<bool> CheckExistAsync<T>(string id, DbSet<T> dbSet) where T : class
        {
            return await dbSet.AnyAsync(x => EF.Property<string>(x, "Id") == id);
        }

        public async Task<string> CreateProductAsync(CreateProductRequest request, CancellationToken cancellationToken)
        {
            if (await _context.Products.AnyAsync(p => p.Name == request.Name || p.ImageUrl == request.ImageUrl || p.Description == request.Description))
            {
                throw new ConflictException("A product with the same details already exists.");
            }
            if (await CheckExistAsync(request.CategoryId, _context.Categories) && await CheckExistAsync(request.GenderId,
                _context.Genders) && await CheckExistAsync(request.SizeId, _context.Sizes))
            {
                var product = _mapper.Map<ClothesStore.Domain.Entities.Product>(request);
                product.CreatedOn = DateTime.Now;
                product.IsRelease = true;
                _context.Products.Add(product);
                await _context.SaveToDbAsync();
                return JsonConvert.SerializeObject(new { Message = "Product is added succesfully" });
            }
            else
            {
                throw new NotFoundException("No such category, size or gender exists!");
            }
        }

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

        public async Task<List<GetAllProductsResponse>> GetProductsAsync(GetAllProductsRequest request, CancellationToken cancellationToken)
        {
            var query = (from p in _context.Products
                         join c in _context.Categories on p.CategoryId equals c.Id
                         join s in _context.Sizes on p.SizeId equals s.Id
                         join g in _context.Genders on p.GenderId equals g.Id
                         where p.IsRelease && c.DeletedOn == null && s.DeletedOn == null && g.DeletedOn == null
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

        public async Task<string> UpdateProductAsync(UpdateProductCommand command, CancellationToken cancellationToken)
        {
           
            var existingProduct = await _context.Products.FindAsync(command.Id);
            if (existingProduct == null)
                throw new NotFoundException("Product not found.");
            _mapper.Map(command, existingProduct);
            await _context.SaveToDbAsync();
            return JsonConvert.SerializeObject(new { Message = "Product is updated succesfully" });
        }
    }
}
