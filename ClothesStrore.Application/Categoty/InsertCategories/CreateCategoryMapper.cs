using ClothesStore.Domain.Entities;

namespace ClothesStrore.Application.Categoty.InsertCategories
{
    public class CreateCategoryMapper : Profile
    {
        public CreateCategoryMapper()
        {
            CreateMap<CreateCategoryRequest, Category>()
            .ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.Name))
            .ForMember(dest => dest.CreatedOn, opt => opt.MapFrom(src => DateTime.Now));
        }
    }
}
