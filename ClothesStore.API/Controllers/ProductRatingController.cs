using ClothesStrore.Application.ProductsRating.GetProductRatings;
using ClothesStrore.Application.ProductsRating.InsertProductRatings;
using Microsoft.AspNetCore.Mvc;

namespace ClothesStore.API.Controllers
{
    [Route("api/product-ratings")]
    [ApiController]
    public class ProductRatingController : ApiControllerBase
    {
        [HttpGet("get-all-product-ratings")]
        public async Task<ActionResult> GetAllProductRatings()
        {
            var response = await Mediator.Send(new GetAllProductRatingRequest());
            return Ok(response);
        }
        [HttpPost("create-rating-product")]
        public async Task<ActionResult> CreateProductRating([FromBody] CreateProductRatingRequest payload)
        {
            var response = await Mediator.Send(payload);
            return Ok(response);
        }
    }
}
