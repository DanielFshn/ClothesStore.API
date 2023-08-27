using FluentValidation;

namespace ClothesStrore.Application.Product.DeleteProduct;

public class DeleteProductValidator : AbstractValidator<DeleteProductRequest>
{
    public DeleteProductValidator()
    {
        RuleFor(x => x.ProductId).NotNull().WithMessage("Product Id can't be empty!");
    }
}
