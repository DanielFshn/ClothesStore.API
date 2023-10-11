using ClothesStrore.Application.Context;

namespace ClothesStrore.Application.Product.GetProducts;

public class GetProductsCommandHandler : IRequestHandler<GetAllProductsRequest, List<GetAllProductsResponse>>
{
    public IMapper _mapper { get; }
    public IMyDbContext _context { get; }
    public UserManager<IdentityUser> _userManage { get; }
    public IProductService _service { get; }

    public GetProductsCommandHandler(IMapper mapper, IMyDbContext context, UserManager<IdentityUser> userManager, IProductService service) =>
    (_mapper, _context, _userManage, _service) = (mapper, context, userManager, service);


    public async Task<List<GetAllProductsResponse>> Handle(GetAllProductsRequest request, CancellationToken cancellationToken) =>
        await _service.GetProductsAsync(request, cancellationToken);
    
}
