

namespace ClothesStrore.Application.Genders.DeleteGender
{
    public class DeleteGenderRequest : IRequest<string>
    {
        public string GednerId { get; set; }
    }
}
