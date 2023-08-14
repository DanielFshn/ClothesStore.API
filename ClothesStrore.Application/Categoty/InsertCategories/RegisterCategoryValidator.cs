using FluentValidation;

namespace ClothesStrore.Application.Categoty.InsertCategories
{
    public class RegisterCategoryValidator : AbstractValidator<CreateCategoryRequest>
    {
        public RegisterCategoryValidator()
        {
            RuleFor(x => x.Name).NotEmpty();
        }
    }
}
