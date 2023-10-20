using AutoMapper;
using ClothesStrore.Application.Common.Exceptions;
using ClothesStrore.Application.Context;
using ClothesStrore.Application.Product;
using ClothesStrore.Application.Product.GetById;
using ClothesStrore.Application.Product.GetProducts;
using ClothesStrore.Application.Product.InsertProduct;
using ClothesStrore.Application.Product.UpdateProdduct;
using Microsoft.Data.SqlClient;
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

        public async Task<bool> CheckExistAsync<T>(string id, DbSet<T> dbSet) where T : class =>
            await dbSet.AnyAsync(x => EF.Property<string>(x, "Id") == id);
        

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
            var userIdParameter = new SqlParameter("@UserId", request.UserId as object ?? DBNull.Value);
            var idParameter = new SqlParameter("@Id", request.Id as object ?? DBNull.Value);
            var categoryParameter = new SqlParameter("@Category", request.Category as object ?? DBNull.Value);
            var sizeParameter = new SqlParameter("@Size", request.Size as object ?? DBNull.Value);
            var genderParameter = new SqlParameter("@Gender", request.Gender as object ?? DBNull.Value);

            var query = _context.GetAllProductsResponses.FromSqlRaw("EXEC GetFilteredProducts @UserId, @Id, @Category, @Size, @Gender",
                userIdParameter, idParameter, categoryParameter, sizeParameter, genderParameter);
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
