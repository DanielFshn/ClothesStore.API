using ClothesStrore.Application.Context;
using ClothesStrore.Application.Helpers;
using Microsoft.EntityFrameworkCore;

namespace ClothesStrore.Application.Categoty.GetCategories
{
    public class GetAllCategoriesRequestHandler : IRequestHandler<GetAllCategoriesRequest, List<GetAllCategoriesResponse>>
    {
        public IMapper _mapper { get; }
        public IMyDbContext _context { get; }

        public GetAllCategoriesRequestHandler(IMapper mapper, IMyDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }



        public async Task<List<GetAllCategoriesResponse>> Handle(GetAllCategoriesRequest request, CancellationToken cancellationToken)
        {
            //var categories = await _context.Categories.Where(c => c.DeletedOn == null).ToListAsync(cancellationToken);
            //var response = _mapper.Map<List<GetAllCategoriesResponse>>(categories);
            //return response;
            var query = _context.Categories.Where(x => x.DeletedOn == null).OrderBy(x => x.CategoryName).AsQueryable();
            //if (request.pagination.Page > 0 && request.pagination.RecordsPerPage > 0)
                query = query.Paginate(request.pagination);
            var categories = await query.ToListAsync(cancellationToken);
            return _mapper.Map<List<GetAllCategoriesResponse>>(categories);

        }
    }
}
