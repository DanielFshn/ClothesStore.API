using ClothesStrore.Application.ProductsRating.GetProductRatings;
using ClothesStrore.Application.ProductsRating.InsertProductRatings;
using ClothesStrore.Application.ProductsRating.UpdateProductRating;
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
        [HttpPut("product-rating-edit")]
        public async Task<ActionResult> EditProductRating(string id, [FromBody] UpdateProductRatingDto request)
        {
            var response = new UpdateProductRatingCommand()
            {
                ProductId = id,
                updateProdutRatingDto = request
            };
            var result = await Mediator.Send(response);
            return Ok(result);
        }
    }
}
