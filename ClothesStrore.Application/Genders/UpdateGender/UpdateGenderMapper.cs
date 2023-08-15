namespace ClothesStrore.Application.Genders.UpdateGender
{
    public class UpdateGenderMapper : Profile
    {
        public UpdateGenderMapper()
        {
            CreateMap<UpdateGenderCommand, ClothesStore.Domain.Entities.Gender>()
         .ForPath(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
         .ForPath(dest => dest.UpdatedOn, opt => opt.MapFrom(src => DateTime.Now))
         .ForPath(dest => dest.GenderName, opt => opt.MapFrom(src => src.UpdateRequest.Name));
        }
    }
}
