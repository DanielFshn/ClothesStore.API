using ClothesStrore.Application.ProductsRating.GetProductRatings;
using ClothesStrore.Application.ProductsRating.InsertProductRatings;
using ClothesStrore.Application.ProductsRating.UpdateProductRating;

namespace ClothesStrore.Application.ProductsRating;

public interface IProductRating
{
    Task<string> CreateAsync(CreateProductRatingRequest request, CancellationToken cancellationToken);
    Task<string> UpdateAsync(UpdateProductRatingCommand request, CancellationToken cancellationToken);
    Task<List<GetAllProductRatingResponse>> GetAsync(GetAllProductRatingRequest request, CancellationToken cancellationToken);
}
