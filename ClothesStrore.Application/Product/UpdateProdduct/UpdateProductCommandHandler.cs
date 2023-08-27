using ClothesStrore.Application.Common.Exceptions;
using ClothesStrore.Application.Context;

namespace ClothesStrore.Application.Product.UpdateProdduct;

public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, string>
{
    public IMapper _mapper { get; }
    public IMyDbContext _context { get; }
    public UpdateProductCommandHandler(IMapper mapper, IMyDbContext context)
    {
        _mapper = mapper;
        _context = context;
    }

    public async Task<string> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
    {
        var existingProduct = await _context.Products.FindAsync(request.Id);
        if (existingProduct == null)
            throw new NotFoundException("Product not found.");
        _mapper.Map(request, existingProduct);
        await _context.SaveToDbAsync();
        return JsonConvert.SerializeObject(new { Message = "Product is updated succesfully" });
    }
}
