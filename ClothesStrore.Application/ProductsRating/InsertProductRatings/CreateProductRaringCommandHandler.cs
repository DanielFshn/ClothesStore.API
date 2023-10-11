namespace ClothesStrore.Application.ProductsRating.InsertProductRatings;

public class CreateProductRaringCommandHandler : IRequestHandler<CreateProductRatingRequest, string>
{
    private readonly IProductRating _service;

    public CreateProductRaringCommandHandler(IProductRating service) =>
        _service = service;

    public async Task<string> Handle(CreateProductRatingRequest request, CancellationToken cancellationToken) =>
        await _service.CreateAsync(request, cancellationToken);
    
}
