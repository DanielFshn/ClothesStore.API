namespace ClothesStrore.Application.Product.GetProducts;

public class GetAllProductsRequest : IRequest<List<GetAllProductsResponse>>
{
    public string? UserId { get; set; }
    public string? Id { get; set; }
    public string? Category { get; set; }
    public string? Size { get; set; }
    public string? Gender { get; set; }
}
