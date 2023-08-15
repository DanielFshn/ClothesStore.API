namespace ClothesStrore.Application.Gender.GetGenders
{
    public class GetAllGendersMapper : Profile
    {
        public GetAllGendersMapper()
        {
            CreateMap<ClothesStore.Domain.Entities.Gender, GetAllGenderResponse>()
                .ForMember(des => des.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(des => des.Name, opt => opt.MapFrom(src => src.GenderName));
        }
    }
}
