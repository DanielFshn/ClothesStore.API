namespace ClothesStrore.Application.Product.DeleteProduct;
public class DeleteProductRequest : IRequest<string>
{
    public string ProductId { get; set; }
}
