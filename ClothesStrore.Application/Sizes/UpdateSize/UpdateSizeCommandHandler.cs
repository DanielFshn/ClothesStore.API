namespace ClothesStrore.Application.Sizes.UpdateSize
{
    public class UpdateSizeCommandHandler : IRequestHandler<UpdateSizeCommand, string>
    {
        private readonly ISizeService _service;

        public UpdateSizeCommandHandler(ISizeService setrvice) =>
            _service = setrvice;

        public async Task<string> Handle(UpdateSizeCommand request, CancellationToken cancellationToken) =>
            await _service.UpdateAsync(request, cancellationToken);
    }
}
