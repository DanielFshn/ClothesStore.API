using ClothesStrore.Application.Stripe.AddStripe;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Stripe;

namespace ClothesStore.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StripeController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public StripeController(IConfiguration configuration) =>
            _configuration = configuration;

        [HttpPost("create-payment-intent")]
        [Authorize(Roles = "Admin,User")]
        public async Task<ActionResult> CreatePaymentIntent([FromBody] PaymentIntentRequest request)
        {
            var amount = request.Amount;
            StripeConfiguration.ApiKey = _configuration["Stripe:SecretKey"];
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
                return Ok(new { client_secret = intent.ClientSecret });
            }
            catch (StripeException ex)
            {
                Console.WriteLine(ex.ToString());
                return BadRequest(new { error = ex.StripeError.Message });
            }
        }
    }
}
