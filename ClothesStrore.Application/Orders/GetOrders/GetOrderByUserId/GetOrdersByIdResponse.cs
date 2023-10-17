namespace ClothesStrore.Application.Orders.GetOrders.GetOrderByUserId;

public class GetOrdersByIdResponse
{
    public string ProductName { get; set; }
    public int Quantity { get; set; }
    public decimal UnitPrice { get; set; }
    public DateTime OrderDate { get; set; }
    public string Address { get; set; }
}
