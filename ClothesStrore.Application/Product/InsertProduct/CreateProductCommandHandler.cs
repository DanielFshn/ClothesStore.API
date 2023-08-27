using ClothesStrore.Application.Common.Exceptions;
using ClothesStrore.Application.Context;
using Microsoft.EntityFrameworkCore;

namespace ClothesStrore.Application.Product.InsertProduct;

public class CreateProductCommandHandler : IRequestHandler<CreateProductRequest, string>
{
    public IMapper _mapper { get; }
    public IMyDbContext _context { get; }

    public CreateProductCommandHandler(IMapper mapper, IMyDbContext context)
    {
        _mapper = mapper;
        _context = context;
    }

    public async Task<string> Handle(CreateProductRequest request, CancellationToken cancellationToken)
    {
        if (await _context.Products.AnyAsync(p => p.Name == request.Name || p.ImageUrl == request.ImageUrl || p.Description == request.Description))
        {
            throw new ConflictException("A product with the same details already exists.");
        }
        var product = _mapper.Map<ClothesStore.Domain.Entities.Product>(request);
        product.CreatedOn = DateTime.Now;
        product.IsRelease = true;
        _context.Products.Add(product);
        await _context.SaveToDbAsync();
        return JsonConvert.SerializeObject(new { Message = "Product is added succesfully" });
    }
}
