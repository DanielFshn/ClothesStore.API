namespace ClothesStrore.Application.Sizes.InsertSizes
{
    public class CreateSizeCommandHandler : IRequestHandler<CreateSizeRequest, string>
    {
        public readonly ISizeService _service;
        public CreateSizeCommandHandler(ISizeService service) =>
            _service = service;

        public async Task<string> Handle(CreateSizeRequest request, CancellationToken cancellationToken) =>
            await _service.CreateAsync(request, cancellationToken);
    }
}
