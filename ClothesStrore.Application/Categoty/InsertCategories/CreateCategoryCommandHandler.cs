using ClothesStore.Domain.Entities;
using ClothesStrore.Application.Common.Exceptions;
using ClothesStrore.Application.Context;
using Microsoft.EntityFrameworkCore;

namespace ClothesStrore.Application.Categoty.InsertCategories
{
    public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryRequest, string>
    {
        public IMapper _mapper { get; }
        public IMyDbContext _context { get; }
        public CreateCategoryCommandHandler(IMapper mapper, IMyDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<string> Handle(CreateCategoryRequest request, CancellationToken cancellationToken)
        {
            if (await _context.Categories.AnyAsync(c => c.CategoryName.ToLower() == request.Name.ToLower(), cancellationToken))
            {
                throw new ConflictException("A category with the same Name already exists.");
            }
            var category = _mapper.Map<Category>(request);
            _context.Categories.Add(category);
            await _context.SaveToDbAsync();
            return "{\"Message\":\"Category is added succesfully\"}";
        }
    }
}
