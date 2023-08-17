using ClothesStore.Domain.Entities;

namespace ClothesStrore.Application.Sizes.InsertSizes
{
    public class CreateSizeMapper : Profile
    {
        public CreateSizeMapper()
        {
            CreateMap<CreateSizeRequest, Size>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name));
        }
    }
}
