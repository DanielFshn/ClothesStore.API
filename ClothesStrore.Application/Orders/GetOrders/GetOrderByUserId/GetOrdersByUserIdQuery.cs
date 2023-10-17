
namespace ClothesStrore.Application.Orders.GetOrders.GetOrderByUserId
{
    public record GetOrdersByUserIdQuery(Guid id) : IRequest<List<GetOrdersByIdResponse>>;
}
