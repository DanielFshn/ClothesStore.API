using ClothesStore.API.Common;
using ClothesStrore.Application.Categoty.DeleteCategory;
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
            var result = await Mediator.Send(payload);
            var jsonObject = Deserialize.JsonDeserialize(result);
            jsonObject.TryGetValue("Message", out var message);
            if (message != null)
                return Ok(message);
            else
                return BadRequest();
        }
        [HttpPut("update/{id}")]
        public async Task<ActionResult> UpdateProduct(string id, [FromBody] UpdateCategoryRequest request)
        {
            var updateCommand = new UpdateCategoryCommand
            {
                CategoryId = id,
                UpdateData = request
            };

            var result =  await Mediator.Send(updateCommand);
            
            return Ok(Deserialize.JsonDeserialize(result));
        }
        [HttpPut("delete")]
        public async Task<ActionResult> DeleteCategory([FromBody] DeleteCategoryRequest request)
        {
            var result = await Mediator.Send(request);
            return Ok(Deserialize.JsonDeserialize(result));
        }
    }
}
