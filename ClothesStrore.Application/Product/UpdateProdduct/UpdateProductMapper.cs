namespace ClothesStrore.Application.Product.UpdateProdduct;

public class UpdateProductMapper : Profile
{
    public UpdateProductMapper()
    {
        CreateMap<UpdateProductCommand, ClothesStore.Domain.Entities.Product>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.CreatedOn, opt => opt.MapFrom(src => DateTime.Now))
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.UpdateProductDto.Name))
            .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.UpdateProductDto.Price))
            .ForMember(dest => dest.Quantity, opt => opt.MapFrom(src => src.UpdateProductDto.Quantity))
            .ForMember(dest => dest.CategoryId, opt => opt.MapFrom(src => src.UpdateProductDto.CategoryId))
            .ForMember(dest => dest.SizeId, opt => opt.MapFrom(src => src.UpdateProductDto.SizeId))
            .ForMember(dest => dest.GenderId, opt => opt.MapFrom(src => src.UpdateProductDto.GenderId))
            .ForMember(dest => dest.ImageUrl, opt => opt.MapFrom(src => src.UpdateProductDto.ImageUrl))
            .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.UpdateProductDto.Description));
    }
}
