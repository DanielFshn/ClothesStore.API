namespace ClothesStrore.Application.UploadFile.SaveFile
{
    public class SaveFileReuqestHandler : IRequestHandler<SaveFileRequest, string>
    {
        private readonly IFileService _fileService;

        public SaveFileReuqestHandler(IFileService fileService) =>
            _fileService = fileService;


        public async Task<string> Handle(SaveFileRequest request, CancellationToken cancellationToken) =>
            await _fileService.SaveFileAsync(request);
    }
}
