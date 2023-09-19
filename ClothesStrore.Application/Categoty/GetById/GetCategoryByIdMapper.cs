namespace ClothesStrore.Application.Categoty.GetById;

public class GetCategoryByIdMapper : Profile
{
    public GetCategoryByIdMapper()
    {
        CreateMap<Category, GetCategoryByIdResponse>()
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.CategoryName));
    }
}
