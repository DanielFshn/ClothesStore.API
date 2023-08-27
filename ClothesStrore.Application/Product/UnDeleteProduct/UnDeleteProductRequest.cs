namespace ClothesStrore.Application.Product.UnDeleteProduct;

public class UnDeleteProductRequest : IRequest<string>
{
    public string ProductId { get; set; }
}
