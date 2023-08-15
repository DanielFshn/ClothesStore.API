using ClothesStrore.Application.Categoty.UpdateCategory;
using FluentValidation;


namespace ClothesStrore.Application.Genders.UpdateGender
{
    public class UpdateGenderValidator : AbstractValidator<UpdateCategoryCommand>
    {
        public UpdateGenderValidator()
        {
            RuleFor(x => x.UpdateData).NotEmpty();
            RuleFor(x => x.UpdateData.Name).NotEmpty();

        }
    }
}
