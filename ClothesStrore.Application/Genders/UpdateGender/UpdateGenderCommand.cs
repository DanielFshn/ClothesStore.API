

namespace ClothesStrore.Application.Genders.UpdateGender
{
    public class UpdateGenderCommand : IRequest<string>
    {
        public string Id { get; set; }
        public UpdateGenderRequest UpdateRequest { get; set; }
        public DateTime UpdatedOn { get; set; }
    }
}
