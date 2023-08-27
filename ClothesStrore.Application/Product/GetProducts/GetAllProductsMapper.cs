namespace ClothesStrore.Application.Product.GetProducts;

public class GetAllProductsMapper : Profile
{
    public GetAllProductsMapper()
    {
        CreateMap<ClothesStore.Domain.Entities.Product, GetAllProductsResponse>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
            .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
            .ForMember(dest => dest.ImageUrl, opt => opt.MapFrom(src => src.ImageUrl))
            .ForMember(dest => dest.CategoryName, opt => opt.Ignore())
            .ForMember(dest => dest.GenderName, opt => opt.Ignore())
            .ForMember(dest => dest.SizeName, opt => opt.Ignore());
    }
}
