using ClothesStrore.Application.Categoty.GetCategories;
using ClothesStrore.Application.Common.Exceptions;
using ClothesStrore.Application.Context;
using Microsoft.EntityFrameworkCore;

namespace ClothesStrore.Application.Categoty.GetById;

public class GetCategoryByIdCommandHandler : IRequestHandler<GetCategoryByIdRequest, GetCategoryByIdResponse>
{
    public IMyDbContext _context { get; }

    private IMapper _mapper { get; }

    public GetCategoryByIdCommandHandler(IMyDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<GetCategoryByIdResponse> Handle(GetCategoryByIdRequest request, CancellationToken cancellationToken)
    {
        var category = await _context.Categories.FirstOrDefaultAsync(x => x.Id == request.Id);
        if (category == null)
            throw new NotFoundException("Category not found");
        var categoryDTO = _mapper.Map<GetCategoryByIdResponse>(category);
        return categoryDTO;
    }
}
