
using ClothesStrore.Application.Helpers;

namespace ClothesStrore.Application.Categoty.GetCategories
{
    public class GetAllCategoriesRequest : IRequest<List<GetAllCategoriesResponse>>
    {
        public PaginationDTO? pagination { get; set; }
    }
}
