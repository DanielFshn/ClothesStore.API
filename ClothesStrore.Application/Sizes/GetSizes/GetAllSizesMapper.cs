using ClothesStore.Domain.Entities;

namespace ClothesStrore.Application.Sizes.GetSizes
{
    public class GetAllSizesMapper : Profile
    {
        public GetAllSizesMapper()
        {
            CreateMap<Size, GetAllSizesResponse>()
                .ForMember(des => des.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name));
        }
    }
}
