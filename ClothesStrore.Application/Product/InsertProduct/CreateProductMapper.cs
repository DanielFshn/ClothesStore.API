namespace ClothesStrore.Application.Product.InsertProduct;

public class CreateProductMapper : Profile
{
    public CreateProductMapper()
    {
        CreateMap<CreateProductRequest, ClothesStore.Domain.Entities.Product>();
    }
}
