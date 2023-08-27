using ClothesStrore.Application.Common.Exceptions;
using ClothesStrore.Application.Context;
using Microsoft.EntityFrameworkCore;

namespace ClothesStrore.Application.Product.DeleteProduct;

public class DeleteProductCommandHandler : IRequestHandler<DeleteProductRequest, string>
{
    public IMapper _mapper { get; }
    public IMyDbContext _context { get; }
    public DeleteProductCommandHandler(IMapper mapper, IMyDbContext context)
    {
        _mapper = mapper;
        _context = context;
    }

    public async Task<string> Handle(DeleteProductRequest request, CancellationToken cancellationToken)
    {
        var product = await _context.Products.FindAsync(request.ProductId);
        if (product == null)
            throw new NotFoundException("Product not found.");
        _mapper.Map(request, product);
        product.DeletedOn = DateTime.Now;
        product.IsRelease = false;
        await _context.SaveToDbAsync();
        return JsonConvert.SerializeObject(new { Message = "Product is deleted succesfully" });
    }
}
