namespace ClothesStrore.Application.Stripe.AddStripe;

public class PaymentIntentRequest : IRequest<string>
{
    public int Amount { get; set; }
    public string id { get; set; }
}
