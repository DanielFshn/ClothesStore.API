using FluentValidation;


namespace ClothesStrore.Application.Categoty.UpdateCategory
{
    public class UpdateCategoryValidator : AbstractValidator<UpdateCategoryCommand>
    {
        public UpdateCategoryValidator()
        {
            RuleFor(x => x.CategoryId).NotEmpty();
            RuleFor(x => x.UpdateData).NotEmpty();
        }
    }
}
