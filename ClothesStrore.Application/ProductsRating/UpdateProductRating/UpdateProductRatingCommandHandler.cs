namespace ClothesStrore.Application.ProductsRating.UpdateProductRating
{
    public class UpdateProductRatingCommandHandler : IRequestHandler<UpdateProductRatingCommand, string>
    {
        private readonly IProductRating _service;

        public UpdateProductRatingCommandHandler(IProductRating service) =>
            _service = service;
        public async Task<string> Handle(UpdateProductRatingCommand request, CancellationToken cancellationToken) =>
            await _service.UpdateAsync(request, cancellationToken);
        
    }
}
