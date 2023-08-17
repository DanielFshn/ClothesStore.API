
namespace ClothesStrore.Application.Sizes.DeleteSize
{
    public class DeleteSizeRequest : IRequest<string>
    {
        public string Id { get; set; }
    }
}
