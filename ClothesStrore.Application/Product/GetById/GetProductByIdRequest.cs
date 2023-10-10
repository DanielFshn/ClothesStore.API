namespace ClothesStrore.Application.Product.GetById
{
    public record GetProductByIdRequest(Guid id) : IRequest<GetProductByIdResponse>;
}
