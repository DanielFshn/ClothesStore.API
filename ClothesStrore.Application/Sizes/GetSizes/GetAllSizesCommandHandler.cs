namespace ClothesStrore.Application.Sizes.GetSizes
{
    public class GetAllSizesCommandHandler : IRequestHandler<GetAllSizesRequest, List<GetAllSizesResponse>>
    {
        private readonly ISizeService _service;

        public GetAllSizesCommandHandler(ISizeService service) =>
            _service = service;

        public async Task<List<GetAllSizesResponse>> Handle(GetAllSizesRequest request, CancellationToken cancellationToken) =>
            await _service.GetAsync(request, cancellationToken);
        
    }
}
