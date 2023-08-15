

namespace ClothesStrore.Application.Categoty.DeleteCategory
{
    public class DeleteCategoryRequest : IRequest<string>
    {
        public string CategoryId { get; set; }
        public DateTime DeletedOn { get; set; } = DateTime.Now;
    }
}
