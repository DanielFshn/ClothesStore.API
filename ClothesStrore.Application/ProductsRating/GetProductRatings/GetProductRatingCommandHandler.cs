namespace ClothesStrore.Application.ProductsRating.GetProductRatings;

public class GetProductRatingCommandHandler : IRequestHandler<GetAllProductRatingRequest, List<GetAllProductRatingResponse>>
{
    private readonly IProductRating _service;

    public GetProductRatingCommandHandler(IProductRating service) =>
        _service = service;

    public async Task<List<GetAllProductRatingResponse>> Handle(GetAllProductRatingRequest request, CancellationToken cancellationToken) =>
        await _service.GetAsync(request, cancellationToken);
}
