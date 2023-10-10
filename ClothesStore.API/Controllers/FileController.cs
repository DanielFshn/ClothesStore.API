using ClothesStrore.Application.UploadFile.SaveFile;
using Microsoft.AspNetCore.Mvc;

namespace ClothesStore.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileController : ApiControllerBase
    {
        [HttpPost]
        public async Task<ActionResult> UploadImage([FromForm] SaveFileRequest request)
        {
            return Ok(await Mediator.Send(request));
        }
    }
}
