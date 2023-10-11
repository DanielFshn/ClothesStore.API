namespace ClothesStrore.Application.Genders.DeleteGender
{
    public class DeleteGenderCommandHandler : IRequestHandler<DeleteGenderRequest, string>
    {
        public IGenderService _service { get; }
        public DeleteGenderCommandHandler(IGenderService service) =>
            _service = service;
        

        public async Task<string> Handle(DeleteGenderRequest request, CancellationToken cancellationToken) =>
            await _service.DeleteGenderAsync(request, cancellationToken);
    }
}
