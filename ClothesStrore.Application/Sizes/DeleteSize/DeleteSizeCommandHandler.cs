namespace ClothesStrore.Application.Sizes.DeleteSize
{
    public class DeleteSizeCommandHandler : IRequestHandler<DeleteSizeRequest, string>
    {
        public readonly ISizeService _service;
        public DeleteSizeCommandHandler(ISizeService service) =>
            _service = service;

        public async Task<string> Handle(DeleteSizeRequest request, CancellationToken cancellationToken) =>
            await _service.DeleteAsync(request, cancellationToken);
      
    }
}
