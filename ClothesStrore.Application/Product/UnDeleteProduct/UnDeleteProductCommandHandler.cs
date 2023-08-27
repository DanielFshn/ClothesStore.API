using ClothesStrore.Application.Common.Exceptions;
using ClothesStrore.Application.Context;

namespace ClothesStrore.Application.Product.UnDeleteProduct;

public class UnDeleteProductCommandHandler : IRequestHandler<UnDeleteProductRequest, string>
{
    public IMyDbContext _context { get; }
    public UnDeleteProductCommandHandler(IMyDbContext context)
    {
        _context = context;
    }

    public async Task<string> Handle(UnDeleteProductRequest request, CancellationToken cancellationToken)
    {
        var product = await _context.Products.FindAsync(request.ProductId);
        if (product == null)
            throw new NotFoundException("Product doen't exist");
        product.IsRelease = true;
        await _context.SaveToDbAsync();
        return JsonConvert.SerializeObject(new { Message = "Product is undeleted succesfully" });
    }
}
