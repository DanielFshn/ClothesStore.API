using Microsoft.AspNetCore.Http;

namespace ClothesStrore.Application.UploadFile.SaveFile;

public class SaveFileRequest : IRequest<string>
{
    public string FileName { get; set; }
    public IFormFile FormFile { get; set; }
}
