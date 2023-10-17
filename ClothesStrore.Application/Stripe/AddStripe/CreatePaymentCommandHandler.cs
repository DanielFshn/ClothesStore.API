namespace ClothesStrore.Application.Stripe.AddStripe
{
    public class CreatePaymentCommandHandler : IRequestHandler<PaymentIntentRequest, string>
    {
        public IPaymentService _service { get; }
        public CreatePaymentCommandHandler(IPaymentService service) =>
            _service = service;
        
        public async Task<string> Handle(PaymentIntentRequest request, CancellationToken cancellationToken) =>
            await _service.CreatePaymentIntentAsync(request);
        
    }
}
