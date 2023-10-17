namespace ClothesStrore.Application.Orders.AddOrder
{
    internal class AddOrderRequestHandler : IRequestHandler<AddOrderRequest, string>
    {
        private readonly IOrderService _service;

        public AddOrderRequestHandler(IOrderService service) =>
            _service = service;

        public Task<string> Handle(AddOrderRequest request, CancellationToken cancellationToken) =>
            _service.AddOrderAsync(request, cancellationToken); 
        
    }
}
