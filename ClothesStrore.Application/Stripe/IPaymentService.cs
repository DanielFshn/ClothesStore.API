using ClothesStrore.Application.Stripe.AddStripe;

namespace ClothesStrore.Application.Stripe
{
    public interface IPaymentService
    {
        Task<string> CreatePaymentIntentAsync(PaymentIntentRequest paymentIntentRequest);
    }
}
