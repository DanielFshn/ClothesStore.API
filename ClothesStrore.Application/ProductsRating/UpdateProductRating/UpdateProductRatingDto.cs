namespace ClothesStrore.Application.ProductsRating.UpdateProductRating;

public class UpdateProductRatingDto
{
    public string UserId { get; set; }
    public int RatingNumber { get; set; }
    public string Title { get; set; }
    public string Comments { get; set; }
}
