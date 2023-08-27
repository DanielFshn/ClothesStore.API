using ClothesStore.Domain.Entities;
using ClothesStrore.Application.Context;
using ClothesStrore.Application.Gender.GetGenders;
using Microsoft.EntityFrameworkCore;

namespace ClothesStrore.Application.Product.GetProducts;

public class GetProductsCommandHandler : IRequestHandler<GetAllProductsRequest, List<GetAllProductsResponse>>
{
    public IMapper _mapper { get; }
    public IMyDbContext _context { get; }
    public GetProductsCommandHandler(IMapper mapper, IMyDbContext context)
    {
        _mapper = mapper;
        _context = context;
    }



    public async Task<List<GetAllProductsResponse>> Handle(GetAllProductsRequest request, CancellationToken cancellationToken)
    {

        var response = await (from p in _context.Products
                              join c in _context.Categories on p.CategoryId equals c.Id
                              join s in _context.Sizes on p.SizeId equals s.Id
                              join g in _context.Genders on p.GenderId equals g.Id
                              select new GetAllProductsResponse
                              {
                                  CategoryName = c.CategoryName,
                                  Description = p.Description,
                                  Id = p.Id,
                                  GenderName = g.GenderName,
                                  ImageUrl = p.ImageUrl,
                                  Name = p.Name,
                                  SizeName = s.Name
                              }).ToListAsync();
        
        //var products = await _context.Products.ToListAsync(cancellationToken);
        //var response = _mapper.Map<List<GetAllProductsResponse>>(products);
        //response = await (from p in _context.Products
        //                  join c in _context.Categories on p.CategoryId equals c.Id
        //                  join s in _context.Sizes on p.SizeId equals s.Id
        //                  join g in _context.Genders on p.GenderId equals g.Id
        //                  select new GetAllProductsResponse
        //                  {
        //                      SizeName = s.Name,
        //                      GenderName = g.GenderName,
        //                      CategoryName = c.CategoryName,
        //                  }).ToListAsync();
        return response;
    }
}
