using ClothesStrore.Application.Orders.AddOrder;
using ClothesStrore.Application.Orders.GetOrders.GetOrderByUserId;
using ClothesStrore.Application.Orders.GetOrders.GetOrdersStatistics;

namespace ClothesStrore.Application.Orders;

public interface IOrderService
{
    Task<string> AddOrderAsync(AddOrderRequest request, CancellationToken cancellationToken);
    Task<List<GetOrdersByIdResponse>> GetOrderByUserIdAsync(GetOrdersByUserIdQuery request, CancellationToken cancellationToken);
    Task<List<GetOrdersStatisticsResponse>> InicializeOrderGraphAsync(GetOrdersStatisticsQuery request, CancellationToken cancellationToken);
}
