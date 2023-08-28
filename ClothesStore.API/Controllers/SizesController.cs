using ClothesStore.API.Common;
using ClothesStrore.Application.Sizes.DeleteSize;
using ClothesStrore.Application.Sizes.GetSizes;
using ClothesStrore.Application.Sizes.InsertSizes;
using ClothesStrore.Application.Sizes.UpdateSize;
using Microsoft.AspNetCore.Mvc;

namespace ClothesStore.API.Controllers;

[Route("api/sizes")]
[ApiController]
public class SizesController : ApiControllerBase
{
    [HttpGet("get-all-sizes")]
    public async Task<ActionResult> GetAllSizes()
    {
        var result = await Mediator.Send(new GetAllSizesRequest());
        return Ok(result);
    }
    [HttpPost("insert-size")]
    public async Task<ActionResult> InsertSize([FromBody] CreateSizeRequest payload)
    {
        var result = await Mediator.Send(payload);
        var jsonObject = Deserialize.JsonDeserialize(result);
        jsonObject.TryGetValue("Message", out string messageValue);
        if (messageValue != null)
            return Ok(jsonObject);
        else
            return BadRequest();
    }
    [HttpPut("update-size/{id}")]
    public async Task<ActionResult> UpdateSize(string id, [FromBody] UpdateSizeRequest request)
    {
        var updateCommand = new UpdateSizeCommand
        {
            Id = id,
            UpdateRequest = request
        };
        var result = await Mediator.Send(updateCommand);
        return Ok(Deserialize.JsonDeserialize(result));
    }
    [HttpPut("delete-size")]
    public async Task<ActionResult> DeleteSize([FromQuery] DeleteSizeRequest request)
    {
        var result = await Mediator.Send(request);
        return Ok(Deserialize.JsonDeserialize(result));
    }
}
