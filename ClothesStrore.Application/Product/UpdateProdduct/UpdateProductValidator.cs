using FluentValidation;

namespace ClothesStrore.Application.Product.UpdateProdduct;

public class UpdateProductValidator : AbstractValidator<UpdateProductDto>
{
    public UpdateProductValidator()
    {

        RuleFor(x => x.Name).NotEmpty().WithMessage("Product name can not be empty");
        RuleFor(x => x.Description).NotEmpty().WithMessage("Description can not be empty");
        RuleFor(x => x.Price).NotEmpty().WithMessage("Price can not be empty").Must(p => p > 0);
        RuleFor(x => x.ImageUrl).NotEmpty().WithMessage("Image can not be empty");
        RuleFor(x => x.CategoryId).NotEmpty().WithMessage("Category can not be empty");
        RuleFor(x => x.SizeId).NotEmpty().WithMessage("Size can not be empty");
        RuleFor(x => x.Quantity).NotEmpty().WithMessage("Quantity can not be empty");
        RuleFor(x => x.GenderId).NotEmpty().WithMessage("Gender can not be empty");
    }
}
