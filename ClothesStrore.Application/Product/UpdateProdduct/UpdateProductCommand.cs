namespace ClothesStrore.Application.Product.UpdateProdduct;

public class UpdateProductCommand : IRequest<string>
{
    public string Id { get; set; }
    public UpdateProductDto UpdateProductDto { get; set; }
    public DateTime CreatedOn { get; set; }
}
