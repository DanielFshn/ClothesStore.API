using FluentValidation;

namespace ClothesStrore.Application.Orders.GetOrders.GetOrderByUserId
{
    public class GetOrderByUserIdValidator : AbstractValidator<GetOrdersByUserIdQuery>
    {
        public GetOrderByUserIdValidator()
        {
            RuleFor(x => x.id).NotEmpty().WithMessage("Id is required");
        }
    }
}
