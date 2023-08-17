using ClothesStrore.Application.Sizes.DeleteSize;
using ClothesStrore.Application.Sizes.GetSizes;
using ClothesStrore.Application.Sizes.InsertSizes;
using ClothesStrore.Application.Sizes.UpdateSize;
using Microsoft.AspNetCore.Mvc;

namespace ClothesStore.API.Controllers
{
    [Route("api/sizes")]
    [ApiController]
    public class SizesController : ApiControllerBase
    {
        [HttpGet("getAll")]
        public async Task<ActionResult> GetAllSizes()
        {
            var result = await Mediator.Send(new GetAllSizesRequest());
            return Ok(result);
        }
        [HttpPost("insert")]
        public async Task<ActionResult> InsertSize([FromBody] CreateSizeRequest payload)
        {
            var response = await Mediator.Send(payload);
            if (response != null)
                return Ok(response);
            else
                return BadRequest();
        }
        [HttpPut("update")]
        public async Task<ActionResult> UpdateSize(string id, [FromBody] UpdateSizeRequest request)
        {
            var updateCommand = new UpdateSizeCommand
            {
                Id = id,
                UpdateRequest = request
            };
            return Ok(await Mediator.Send(updateCommand));
        }
        [HttpPut("delete")]
        public async Task<ActionResult> DeleteSize([FromBody] DeleteSizeRequest request)
        {
            return Ok(await Mediator.Send(request));
        }
    }
}
