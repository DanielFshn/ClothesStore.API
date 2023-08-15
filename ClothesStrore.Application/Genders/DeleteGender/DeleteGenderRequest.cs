

namespace ClothesStrore.Application.Genders.DeleteGender
{
    public class DeleteGenderRequest : IRequest<string>
    {
        public string GednerId { get; set; }
        public DateTime DeletedOn { get; set; } = DateTime.Now;
    }
}
