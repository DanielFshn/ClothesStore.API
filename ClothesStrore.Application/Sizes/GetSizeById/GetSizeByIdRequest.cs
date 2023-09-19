namespace ClothesStrore.Application.Sizes.GetSizeById
{
    public class GetSizeByIdRequest : IRequest<GetSizeByIdResponse>
    {
        public string Id { get; set; }

    }
}
