using ClothesStrore.Application.Categoty.GetCategories;
using ClothesStrore.Application.Categoty.InsertCategories;
using ClothesStrore.Application.Categoty.UpdateCategory;
using Microsoft.AspNetCore.Mvc;

namespace ClothesStore.API.Controllers
{
    [Route("api/categories")]
    [ApiController]
    public class CategoriesController : ApiControllerBase
    {

        [HttpGet("getCategories")]
        public async Task<ActionResult> GetAllCategories()
        {
            var response = await Mediator.Send(new GetAllCategoriesRequest());
            return Ok(response);
        }
        [HttpPost("insert")]
        public async Task<ActionResult> InsertCategory([FromBody] CreateCategoryRequest payload)
        {
            var response = await Mediator.Send(payload);
            if (response != null)
                return Ok(response);
            else
                return BadRequest();
        }
        [HttpPut("update")]
        public async Task<ActionResult> UpdateProduct(string id, [FromBody] UpdateCategoryRequest request)
        {
            var updateCommand = new UpdateCategoryCommand
            {
                CategoryId = id,
                UpdateData = request
            };

            await Mediator.Send(updateCommand);

            return Ok("Category updated successfully.");
        }

    }
}
