using ClothesStore.Domain.Entities;

namespace ClothesStrore.Application.Sizes.UpdateSize
{
    public class UpdateSizeMapper : Profile
    {
        public UpdateSizeMapper()
        {
            CreateMap<UpdateSizeCommand, Size>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.UpdateRequest.Name))
                .ForMember(dest => dest.UpdatedOn, opt => opt.MapFrom(src => DateTime.Now));

        }
    }
}
