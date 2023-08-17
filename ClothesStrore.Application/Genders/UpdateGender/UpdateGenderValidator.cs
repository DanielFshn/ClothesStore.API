using FluentValidation;

namespace ClothesStrore.Application.Genders.UpdateGender
{
    public class UpdateGenderValidator : AbstractValidator<UpdateGenderCommand>
    {
        public UpdateGenderValidator()
        {
            RuleFor(x => x.UpdateRequest).NotEmpty();
            RuleFor(x => x.UpdateRequest.Name).NotEmpty();

        }
    }
}
