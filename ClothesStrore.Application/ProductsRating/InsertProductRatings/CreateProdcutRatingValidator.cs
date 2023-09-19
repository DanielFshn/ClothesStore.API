using FluentValidation;

namespace ClothesStrore.Application.ProductsRating.InsertProductRatings;

public class CreateProdcutRatingValidator : AbstractValidator<CreateProductRatingRequest>
{
    public CreateProdcutRatingValidator()
    {
        RuleFor(x => x.ProductId).NotEmpty().WithMessage("Product id can not be empty");
        RuleFor(x => x.UserId).NotEmpty().WithMessage("User id can not be empty");
        RuleFor(x => x.Title).NotEmpty().WithMessage("Title id can not be empty");
        RuleFor(x => x.Comments).NotEmpty().WithMessage("Comments can not be empty");
        RuleFor(x => x.RatingNumber).NotEmpty().WithMessage("RatingNumber can not be empty")
            .Must(number => number >=1 && number <= 5).WithMessage("Rating number must be between 1 and 5");
    }
}
