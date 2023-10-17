namespace ClothesStrore.Application.Orders.GetOrders.GetOrderByUserId
{
    internal class GetOrdersByUserIdCommandHandler : IRequestHandler<GetOrdersByUserIdQuery, List<GetOrdersByIdResponse>>
    {
        private readonly IOrderService _service;

        public GetOrdersByUserIdCommandHandler(IOrderService service) =>
            _service = service;

        public async Task<List<GetOrdersByIdResponse>> Handle(GetOrdersByUserIdQuery request, CancellationToken cancellationToken) =>
                await _service.GetOrderByUserIdAsync(request, cancellationToken);
        
    }
}
