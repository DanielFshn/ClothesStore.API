using ClothesStrore.Application.Product.GetById;
using ClothesStrore.Application.Product.GetProducts;
using ClothesStrore.Application.ProductsRating.GetProductRatings;

namespace ClothesStrore.Application.Product
{
    public interface IProductService
    {
        Task<GetProductByIdResponse> GetProductByIdAsync(GetProductByIdRequest request, CancellationToken cancellationToken);
        Task<List<GetAllProductsResponse>> GetProducts(GetAllProductsRequest request, CancellationToken cancellationToken);
    }
}
