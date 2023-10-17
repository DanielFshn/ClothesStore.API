using ClothesStrore.Application.Stripe;
using ClothesStrore.Application.Stripe.AddStripe;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Stripe;

namespace ClothesStore.Infrastructure.Stripe
{
    public class PaymentService : IPaymentService
    {
        public IConfiguration _configuration { get; }

        public PaymentService(IConfiguration configuration)
        {
            _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
            StripeConfiguration.ApiKey = _configuration["Stripe:SecretKey"];
        }


        public async Task<string> CreatePaymentIntentAsync(PaymentIntentRequest request)
        {
            var amount = request.Amount;
            try
            {
                var options = new PaymentIntentCreateOptions
                {
                    Amount = amount,
                    Currency = "usd",
                    PaymentMethodTypes = new List<string> { "card" },
                    PaymentMethod = request.id,
                    Confirm = true,
                    ReturnUrl = "https://localhost:3000/thankyou"
                };
                var service = new PaymentIntentService();
                var intent = await service.CreateAsync(options);
                return JsonConvert.SerializeObject(new { Message = intent.Status});

            }
            catch (StripeException ex)
            {
                return JsonConvert.SerializeObject(new { Message = ex.StripeError.Message });

            }
        }
    }
}
