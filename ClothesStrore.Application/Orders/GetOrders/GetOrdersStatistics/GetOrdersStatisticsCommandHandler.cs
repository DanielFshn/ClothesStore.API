namespace ClothesStrore.Application.Orders.GetOrders.GetOrdersStatistics;

public class GetOrdersStatisticsCommandHandler : IRequestHandler<GetOrdersStatisticsQuery, List<GetOrdersStatisticsResponse>>
{
    private readonly IOrderService _service;

    public GetOrdersStatisticsCommandHandler(IOrderService service) =>
        _service = service;

    public async Task<List<GetOrdersStatisticsResponse>> Handle(GetOrdersStatisticsQuery request, CancellationToken cancellationToken) =>
        await _service.InicializeOrderGraphAsync(request, cancellationToken);

}
