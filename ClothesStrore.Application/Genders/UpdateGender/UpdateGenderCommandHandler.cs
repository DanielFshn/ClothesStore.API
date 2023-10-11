namespace ClothesStrore.Application.Genders.UpdateGender;

public class UpdateGenderCommandHandler : IRequestHandler<UpdateGenderCommand, string>
{
    private readonly IGenderService _service;

    public UpdateGenderCommandHandler(IGenderService service) =>
        _service = service;

    public async Task<string> Handle(UpdateGenderCommand request, CancellationToken cancellationToken) =>
        await _service.UpateAsync(request, cancellationToken);

}
