namespace ClothesStrore.Application.Genders.GetById;

public class GetGenderByIdRequest : IRequest<GetGenderByIdResponse>
{
    public string Id { get; set; }
}
