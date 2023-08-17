

namespace ClothesStrore.Application.Gender.InsertGender
{
    public class CreateGenderMapper : Profile
    {
        public CreateGenderMapper()
        {
            CreateMap<CreateGenderRequest, ClothesStore.Domain.Entities.Gender>()
                .ForMember(dest => dest.GenderName, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.CreatedOn,opt => opt.MapFrom(src => DateTime.Now));
        }
    }
}
