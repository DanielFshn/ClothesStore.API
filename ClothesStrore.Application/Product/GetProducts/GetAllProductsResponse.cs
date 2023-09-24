namespace ClothesStrore.Application.Product.GetProducts;


public class GetAllProductsResponse
{
    public string Id{ get; set; }
    public string Name {get; set; }
    public string Description {get; set; }
    public decimal Price { get; set; }
    public string ImageUrl {get; set; }
    public string CategoryName {get; set; }
    public string GenderName {get; set; }
    public string SizeName {get; set; }
    public int RatingNumber { get; set; }

}
