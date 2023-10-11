namespace ClothesStrore.Application.Sizes.GetSizeById;

public class GetSizeByIdCommandHandler : IRequestHandler<GetSizeByIdRequest, GetSizeByIdResponse>
{
    public readonly ISizeService _service;
    public GetSizeByIdCommandHandler(ISizeService service) =>
        _service = service;

    public async Task<GetSizeByIdResponse> Handle(GetSizeByIdRequest request, CancellationToken cancellationToken) =>
        await _service.GetByIdAsync(request, cancellationToken);
}
