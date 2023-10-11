namespace ClothesStrore.Application.Categoty.GetCategories
{
    public class GetAllCategoriesRequestHandler : IRequestHandler<GetAllCategoriesRequest, GetAllCategoriesResponse>
    {
        public ICategoryService _service { get; }
        public GetAllCategoriesRequestHandler(ICategoryService servce) =>
            _service = (servce);

        public async Task<GetAllCategoriesResponse> Handle(GetAllCategoriesRequest request, CancellationToken cancellationToken) =>
            await _service.GetCategoriesAsync(request, cancellationToken);
    }
}
