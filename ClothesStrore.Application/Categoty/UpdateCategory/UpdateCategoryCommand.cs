
namespace ClothesStrore.Application.Categoty.UpdateCategory
{
    public class UpdateCategoryCommand : IRequest<string>
    {
        public string CategoryId { get; set; }
        public UpdateCategoryRequest UpdateData { get; set; }
        public DateTime UpdatedOn { get; set; }
    }
}
