
using ClothesStrore.Application.Helpers;

namespace ClothesStrore.Application.Categoty.GetCategories
{
    public class GetAllCategoriesRequest : IRequest <GetAllCategoriesResponse>
    {
        public PaginationDTO? pagination { get; set; }
    }
}
