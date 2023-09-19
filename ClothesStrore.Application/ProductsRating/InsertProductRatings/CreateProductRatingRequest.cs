namespace ClothesStrore.Application.ProductsRating.InsertProductRatings;

public class CreateProductRatingRequest : IRequest<string>
{
    public string ProductId { get; set; }
    public string UserId { get; set; }
    public int RatingNumber { get; set; }
    public string Title { get; set; }
    public string Comments { get; set; }
}
