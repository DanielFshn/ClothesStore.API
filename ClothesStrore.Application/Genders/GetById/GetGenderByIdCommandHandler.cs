namespace ClothesStrore.Application.Genders.GetById;

public class GetGenderByIdCommandHandler : IRequestHandler<GetGenderByIdRequest, GetGenderByIdResponse>
{
    private readonly IGenderService _service;

    public GetGenderByIdCommandHandler(IGenderService service) =>
        _service = service;

    public async Task<GetGenderByIdResponse> Handle(GetGenderByIdRequest request, CancellationToken cancellationToken) =>
        await _service.GetByIdAsync(request, cancellationToken);

}
