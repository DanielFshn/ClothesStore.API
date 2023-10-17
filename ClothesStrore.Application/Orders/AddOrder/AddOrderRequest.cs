using System.ComponentModel.DataAnnotations.Schema;

namespace ClothesStrore.Application.Orders.AddOrder;

public class AddOrderRequest : IRequest<string>
{
    public string UserId { get; set; }
    public decimal TotalAmount { get; set; }
    public List<OrderDetails> Products { get; set; }
    public string Country { get; set; }
    public string City { get; set; }
    public string StreetName { get; set; }
    public string PostalCode { get; set; }
}

public class OrderDetails
{
    public string Id { get; set; }
    public decimal Price  { get; set; }
    public int Quantity { get; set; }
    public string OrderId { get; set; } = "";
}