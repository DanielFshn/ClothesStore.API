
namespace ClothesStrore.Application.Genders.DeleteGender;

public class DeleteGenderMapper : Profile
{
    public DeleteGenderMapper()
    {
        CreateMap<DeleteGenderRequest, ClothesStore.Domain.Entities.Gender>()
        .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.GednerId))
        .ForMember(dest => dest.DeletedOn, opt => opt.MapFrom(src => DateTime.Now));
    }
}
