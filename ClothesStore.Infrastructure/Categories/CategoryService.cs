using AutoMapper;
using ClothesStore.Domain.Entities;
using ClothesStrore.Application.Categoty;
using ClothesStrore.Application.Categoty.DeleteCategory;
using ClothesStrore.Application.Categoty.GetById;
using ClothesStrore.Application.Categoty.GetCategories;
using ClothesStrore.Application.Categoty.InsertCategories;
using ClothesStrore.Application.Categoty.UpdateCategory;
using ClothesStrore.Application.Common.Exceptions;
using ClothesStrore.Application.Context;
using ClothesStrore.Application.Helpers;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace ClothesStore.Infrastructure.Categories;

internal class CategoryService : ICategoryService
{
    public IMyDbContext _context { get; }
    public IMapper _mapper { get; }
    public CategoryService(IMyDbContext context, IMapper mapper) =>
        (_context, _mapper) = (context, mapper);


    public async Task<string> DeleteCategoryAsync(DeleteCategoryRequest request, CancellationToken cancellationToken)
    {
        var category = await _context.Categories.FindAsync(request.CategoryId);
        if (category == null)
            throw new NotFoundException("Category not found.");
        _mapper.Map(request, category);
        await _context.SaveToDbAsync();
        return JsonConvert.SerializeObject(new { Message = "Category is deleted succesfully" });
    }

    public async Task<GetCategoryByIdResponse> GetCategoryByIdAsync(GetCategoryByIdRequest request, CancellationToken cancellationToken)
    {
        var category = await _context.Categories.FirstOrDefaultAsync(x => x.Id == request.Id);
        if (category == null)
            throw new NotFoundException("Category not found");
        var categoryDTO = _mapper.Map<GetCategoryByIdResponse>(category);
        return categoryDTO;
    }

    public async Task<GetAllCategoriesResponse> GetCategoriesAsync(GetAllCategoriesRequest request, CancellationToken cancellationToken)
    {
        //var categories = await _context.Categories.Where(c => c.DeletedOn == null).ToListAsync(cancellationToken);
        //var response = _mapper.Map<List<GetAllCategoriesResponse>>(categories);
        //return response;
        var query = _context.Categories.Where(x => x.DeletedOn == null).OrderBy(x => x.CategoryName).AsQueryable();
        //if (request.pagination.Page > 0 && request.pagination.RecordsPerPage > 0)
        var totalRecords = await query.CountAsync();
        //if (request.pagination.Page > 0 && request.pagination.RecordsPerPage > 0)
        //{
        query = query.Paginate(request.pagination);
        //}
        var categories = await query.ToListAsync(cancellationToken);

        var response = new GetAllCategoriesResponse
        {
            Data = _mapper.Map<List<Data>>(categories),
            TotalRecords = totalRecords
        };
        return response;
    }

    public async Task<string> CreateCategoryAsync(CreateCategoryRequest request, CancellationToken cancellationToken)
    {
        if (await _context.Categories.AnyAsync(c => c.CategoryName.ToLower() == request.Name.ToLower(), cancellationToken))
        {
            throw new ConflictException("A category with the same Name already exists.");
        }
        var category = _mapper.Map<Category>(request);
        _context.Categories.Add(category);
        await _context.SaveToDbAsync();
        return JsonConvert.SerializeObject(new { Message = "Category is added succesfully" });
    }

    public async Task<string> UpdateCategoryAsync(UpdateCategoryCommand request, CancellationToken cancellationToken)
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
