﻿using ClothesStrore.Application.Common.Exceptions;
using ClothesStrore.Application.Context;
using Microsoft.EntityFrameworkCore;

namespace ClothesStrore.Application.Categoty.UpdateCategory
{
    public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommand, string>
    {
        public IMapper _mapper { get; }
        public IMyDbContext _context { get; }
        public UpdateCategoryCommandHandler(IMapper mapper, IMyDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<string> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
        {
            var isTaken = await _context.Categories.AnyAsync(x => x.CategoryName == request.UpdateData.Name);
            if (isTaken)
                throw new DuplicateEntryException("This category name is already exist!");
            var existingCategory = await _context.Categories.FindAsync(request.CategoryId);
            if (existingCategory == null)
                throw new NotFoundException("Category not found.");
            _mapper.Map(request, existingCategory);
            await _context.SaveToDbAsync();
            return JsonConvert.SerializeObject(new { Message = "Category is updated succesfully" });
        }
    }
}
