using ClothesStrore.Application.Common.Exceptions;
using ClothesStrore.Application.Context;


namespace ClothesStrore.Application.Categoty.DeleteCategory
{
    public class DeleteCategoryCommandHandler : IRequestHandler<DeleteCategoryRequest, string>
    {
        public IMapper _mapper { get; }
        public IMyDbContext _context { get; }
        public DeleteCategoryCommandHandler(IMapper mapper, IMyDbContext cotnext)
        {
            _mapper = mapper;
            _context = cotnext;
        }


        public async Task<string> Handle(DeleteCategoryRequest request, CancellationToken cancellationToken)
        {
            var category = await _context.Categories.FindAsync(request.CategoryId);
            if (category == null)
                throw new NotFoundException("Category not found.");
            _mapper.Map(request, category);
            await _context.SaveToDbAsync();
            return "{\"Message\":\"Category is deleted succesfully\"}";
        }
    }
}
