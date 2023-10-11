namespace ClothesStrore.Application.Product.UpdateProdduct;

public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, string>
{
    public IProductService _service { get; }

    public UpdateProductCommandHandler(IProductService service) =>
     (_service) = (service);

    public async Task<string> Handle(UpdateProductCommand request, CancellationToken cancellationToken) =>
        await _service.UpdateProductAsync(request, cancellationToken);
    
}
