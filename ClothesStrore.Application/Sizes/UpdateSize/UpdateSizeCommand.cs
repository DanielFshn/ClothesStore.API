
namespace ClothesStrore.Application.Sizes.UpdateSize
{
    public class UpdateSizeCommand : IRequest<string>
    {
        public string Id { get; set; }
        public UpdateSizeRequest UpdateRequest { get; set; }

    }
}
