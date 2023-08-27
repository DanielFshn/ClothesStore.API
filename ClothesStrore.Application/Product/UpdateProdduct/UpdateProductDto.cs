namespace ClothesStrore.Application.Product.UpdateProdduct;

public class UpdateProductDto
{
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public int Quantity { get; set; }
    public string ImageUrl { get; set; }
    public string CategoryId { get; set; }
    public string SizeId { get; set; }
    public string GenderId { get; set; }
}
