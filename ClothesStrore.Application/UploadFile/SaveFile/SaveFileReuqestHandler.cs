using ClothesStrore.Application.Common.Exceptions;

namespace ClothesStrore.Application.UploadFile.SaveFile
{
    public class SaveFileReuqestHandler : IRequestHandler<SaveFileRequest, string>
    {
        public async Task<string> Handle(SaveFileRequest request, CancellationToken cancellationToken)
        {
            try
            {
                string directoryPath = "C:\\React\\Clothes-Store-FE\\clothes-store-fe\\public\\ProductImages";
                if (!Directory.Exists(directoryPath))
                    Directory.CreateDirectory(directoryPath);
                string fileName = request.FileName;
                string filePath = Path.Combine(directoryPath, fileName);
                if (File.Exists(filePath))
                {
                    throw new BadRequestException("File with the same name already exists.");
                }

                await using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    request.FormFile.CopyTo(stream);
                }
                return JsonConvert.SerializeObject(new { Message = "File is saved sucessfully!" });
            }
            catch (Exception ex)
            {
                throw new InternalServerError(ex.Message);
            }
        }
    }
}
