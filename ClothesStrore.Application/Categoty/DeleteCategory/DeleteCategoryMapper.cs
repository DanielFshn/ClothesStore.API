using ClothesStore.Domain.Entities;

namespace ClothesStrore.Application.Categoty.DeleteCategory
{
    public class DeleteCategoryMapper : Profile
    {
        public DeleteCategoryMapper()
        {
            CreateMap<DeleteCategoryRequest, Category>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.CategoryId))
            .ForMember(dest => dest.DeletedOn, opt => opt.MapFrom(src => src.DeletedOn));
        }
    }
}
