using ClothesStore.API.Common;
using ClothesStrore.Application.Categoty.DeleteCategory;
using ClothesStrore.Application.Categoty.GetCategories;
using ClothesStrore.Application.Categoty.InsertCategories;
using ClothesStrore.Application.Categoty.UpdateCategory;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ClothesStore.API.Controllers;

[Route("api/categories")]
[ApiController]
[Authorize(Roles = "Admin")]
public class CategoriesController : ApiControllerBase
{
    [HttpGet("get-categories")]
    public async Task<ActionResult> GetAllCategories()
    {
        var response = await Mediator.Send(new GetAllCategoriesRequest());
        return Ok(response);
    }
    [HttpPost("insert-category")]
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
    [HttpPut("update-category/{id}")]
    public async Task<ActionResult> UpdateProduct(string id, [FromBody] UpdateCategoryRequest request)
    {
        var updateCommand = new UpdateCategoryCommand
        {
            CategoryId = id,
            UpdateData = request
        };

        var result = await Mediator.Send(updateCommand);

        return Ok(Deserialize.JsonDeserialize(result));
    }
    [HttpPut("delete-category")]
    public async Task<ActionResult> DeleteCategory([FromQuery] DeleteCategoryRequest request)
    {
        var result = await Mediator.Send(request);
        return Ok(Deserialize.JsonDeserialize(result));
    }
}
