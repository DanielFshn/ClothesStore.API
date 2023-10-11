using ClothesStrore.Application.UploadFile.SaveFile;

namespace ClothesStrore.Application.UploadFile;

public interface IFileService
{
    Task<string> SaveFileAsync(SaveFileRequest request);
}
