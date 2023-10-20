using ClothesStrore.Application.UploadFile.SaveFile;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ClothesStore.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileController : ApiControllerBase
    {
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> UploadImage([FromForm] SaveFileRequest request) =>
            Ok(await Mediator.Send(request));
    }
}
