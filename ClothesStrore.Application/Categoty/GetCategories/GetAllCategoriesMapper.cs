using ClothesStore.Domain.Entities;


namespace ClothesStrore.Application.Categoty.GetCategories
{
    public class GetAllCategoriesMapper : Profile
    {
        public GetAllCategoriesMapper()
        {
            CreateMap<Category, Data>()
           .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
           .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.CategoryName));
            
            CreateMap<List<Category>, GetAllCategoriesResponse>()
            .ForMember(dest => dest.Data, opt => opt.MapFrom(src => src));

        }
    }
}
