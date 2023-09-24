
namespace ClothesStrore.Application.ProductsRating.UpdateProductRating;

public class UpdateProductRatingCommand : IRequest<string>
{
    public string ProductId { get; set; }
    public UpdateProductRatingDto updateProdutRatingDto { get; set; }
    public DateTime UpdaetdOn { get; set; }
}
