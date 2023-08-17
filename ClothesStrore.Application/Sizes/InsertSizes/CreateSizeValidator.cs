using FluentValidation;

namespace ClothesStrore.Application.Sizes.InsertSizes
{
    public class CreateSizeValidator : AbstractValidator<CreateSizeRequest>
    {
        public CreateSizeValidator()
        {
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.Name).Length(0, 4)
                .WithMessage("Size name must be between 1 and 4 characters long.");
        }
    }
}
