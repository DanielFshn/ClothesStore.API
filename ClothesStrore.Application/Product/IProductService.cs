using ClothesStrore.Application.Product.GetById;
using ClothesStrore.Application.Product.GetProducts;
using ClothesStrore.Application.Product.InsertProduct;
using ClothesStrore.Application.Product.UpdateProdduct;
using Microsoft.EntityFrameworkCore;

namespace ClothesStrore.Application.Product
{
    public interface IProductService
    {
        Task<GetProductByIdResponse> GetProductByIdAsync(GetProductByIdRequest request, CancellationToken cancellationToken);
        Task<List<GetAllProductsResponse>> GetProductsAsync(GetAllProductsRequest request, CancellationToken cancellationToken);
        Task<string> CreateProductAsync(CreateProductRequest request, CancellationToken cancellationToken);
        Task<bool> CheckExistAsync<T>(string id, DbSet<T> dbSet) where T : class;
        Task<string> UpdateProductAsync(UpdateProductCommand command, CancellationToken cancellationToken); 
    }
}
