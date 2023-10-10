namespace ClothesStrore.Application.Product.GetById
{
    public class GetProductByIdRequestHandler : IRequestHandler<GetProductByIdRequest, GetProductByIdResponse>
    {
        private readonly IProductService _productService;

        public GetProductByIdRequestHandler(IProductService productService) =>
            _productService = productService;



        public async Task<GetProductByIdResponse> Handle(GetProductByIdRequest request, CancellationToken cancellationToken) =>
        await _productService.GetProductByIdAsync(request, cancellationToken);

    }
}
