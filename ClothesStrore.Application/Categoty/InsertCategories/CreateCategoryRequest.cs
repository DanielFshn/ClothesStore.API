
namespace ClothesStrore.Application.Categoty.InsertCategories
{
    public class CreateCategoryRequest : IRequest<string>
    {
        public string Name { get; set; }
    }
}
