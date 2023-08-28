namespace ClothesStrore.Application.Product.DeleteProduct;

public class DeleteProductMapper : Profile
{
    public DeleteProductMapper()
    {
        CreateMap<DeleteProductRequest, ClothesStore.Domain.Entities.Product>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.ProductId))
            .ForMember(dest => dest.DeletedOn , opt => opt.MapFrom(src => DateTime.Now))
            .ForMember(dest => dest.IsRelease , opt => opt.MapFrom(src => false));
    }
}
