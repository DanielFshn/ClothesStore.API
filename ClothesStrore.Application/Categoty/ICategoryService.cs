using ClothesStrore.Application.Categoty.DeleteCategory;
using ClothesStrore.Application.Categoty.GetById;
using ClothesStrore.Application.Categoty.GetCategories;
using ClothesStrore.Application.Categoty.InsertCategories;
using ClothesStrore.Application.Categoty.UpdateCategory;

namespace ClothesStrore.Application.Categoty
{
    public interface ICategoryService
    {
        Task<string> DeleteCategoryAsync(DeleteCategoryRequest request, CancellationToken cancellationToken);
        Task<GetCategoryByIdResponse> GetCategoryByIdAsync(GetCategoryByIdRequest request, CancellationToken cancellationToken);
        Task<GetAllCategoriesResponse> GetCategoriesAsync(GetAllCategoriesRequest request, CancellationToken cancellationToken);
        Task<string> CreateCategoryAsync(CreateCategoryRequest request, CancellationToken cancellationToken);
        Task<string> UpdateCategoryAsync(UpdateCategoryCommand request, CancellationToken cancellationToken);
    }
}
