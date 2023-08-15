using FluentValidation;


namespace ClothesStrore.Application.Gender.InsertGender
{
    public class RegisterGenderValidator : AbstractValidator<CreateGenderRequest>
    {
        public RegisterGenderValidator()
        {
            RuleFor(x => x.Name).NotEmpty();
        }
    }
}
