using FluentValidation;

namespace ClothesStrore.Application.Orders.AddOrder;

public class AddOrderValidator  : AbstractValidator<AddOrderRequest>
{
    public AddOrderValidator()
    {
        RuleFor(request => request.UserId).NotEmpty().WithMessage("UserId is required.");
        RuleFor(request => request.TotalAmount).GreaterThan(0).WithMessage("TotalAmount must be greater than 0.");
        RuleFor(request => request.City).NotEmpty().WithMessage("City is required.");
        RuleFor(request => request.PostalCode).NotEmpty().WithMessage("PostalCode is required.");
        RuleFor(request => request.Country).NotEmpty().WithMessage("Country is required.");
        RuleFor(request => request.StreetName).NotEmpty().WithMessage("StreetName is required.");
        
        RuleForEach(request => request.Products).SetValidator(new OrderDetailsValidator());
    }
}

public class OrderDetailsValidator : AbstractValidator<OrderDetails>
{
    public OrderDetailsValidator()
    {
        RuleFor(product => product.Id).NotEmpty().WithMessage("Product Id is required.");
        RuleFor(product => product.Price).GreaterThan(0).WithMessage("Price must be greater than 0.");
        RuleFor(product => product.QuantityUnit).GreaterThan(0).WithMessage("Quantity unit must be greater than 0.");
    }
}