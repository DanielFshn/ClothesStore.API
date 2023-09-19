namespace ClothesStrore.Application.Genders.GetById
{
    public class GetGenderByIdMapper : Profile
    {
        public GetGenderByIdMapper()
        {
            CreateMap<ClothesStore.Domain.Entities.Gender, GetGenderByIdResponse>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.GenderName));
        }
    }
}
