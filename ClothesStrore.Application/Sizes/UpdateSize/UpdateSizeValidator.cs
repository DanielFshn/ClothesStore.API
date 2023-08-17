
using FluentValidation;

namespace ClothesStrore.Application.Sizes.UpdateSize
{
    public class UpdateSizeValidator : AbstractValidator<UpdateSizeCommand>
    {
        public UpdateSizeValidator()
        {
            RuleFor(x => x.UpdateRequest.Name).NotEmpty();
        }
    }
}
