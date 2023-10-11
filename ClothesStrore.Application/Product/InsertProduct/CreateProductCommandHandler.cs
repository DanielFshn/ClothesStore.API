using ClothesStrore.Application.Common.Exceptions;
using ClothesStrore.Application.Context;
using Microsoft.EntityFrameworkCore;

namespace ClothesStrore.Application.Product.InsertProduct;

public class CreateProductCommandHandler : IRequestHandler<CreateProductRequest, string>
{
    public IMapper _mapper { get; }
    public IMyDbContext _context { get; }
    public IProductService _service { get; }

    public CreateProductCommandHandler(IMapper mapper, IMyDbContext context, IProductService service) =>
        (_mapper, _context, _service) = (mapper, context, service);
    private async Task<bool> CheckExist<T>(string id, DbSet<T> dbSet) where T : class
    {
       return await dbSet.AnyAsync(x => EF.Property<string>(x , "Id") == id);    
    }

    public async Task<string> Handle(CreateProductRequest request, CancellationToken cancellationToken) =>
     await _service.CreateProductAsync(request, cancellationToken);
}
