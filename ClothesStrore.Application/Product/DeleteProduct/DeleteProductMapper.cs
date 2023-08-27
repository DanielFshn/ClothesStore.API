namespace ClothesStrore.Application.Product.DeleteProduct;

public class DeleteProductMapper : Profile
{
    public DeleteProductMapper()
    {
        CreateMap<DeleteProductRequest, ClothesStore.Domain.Entities.Product>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.ProductId));
    }
}
