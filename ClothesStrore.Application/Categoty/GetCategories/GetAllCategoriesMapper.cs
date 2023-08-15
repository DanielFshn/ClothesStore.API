using ClothesStore.Domain.Entities;


namespace ClothesStrore.Application.Categoty.GetCategories
{
    public class GetAllCategoriesMapper : Profile
    {
        public GetAllCategoriesMapper()
        {
            CreateMap<Category, GetAllCategoriesResponse>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.CategoryName))
;
        }
    }
}
