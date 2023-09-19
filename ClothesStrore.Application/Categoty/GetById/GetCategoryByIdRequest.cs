namespace ClothesStrore.Application.Categoty.GetById;

public class GetCategoryByIdRequest : IRequest<GetCategoryByIdResponse>
{
    public string Id { get; set; }
}
