
namespace ClothesStrore.Application.Product.GetById;

public class GetProductByIdMapper : Profile
{
    public GetProductByIdMapper()
    {
        CreateMap<ClothesStore.Domain.Entities.Product, GetProductByIdResponse>();
    }
}
