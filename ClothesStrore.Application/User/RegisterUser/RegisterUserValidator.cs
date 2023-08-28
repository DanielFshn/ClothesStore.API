using ClothesStrore.Application.User.CreaeteUser;
using FluentValidation;

namespace ClothesStrore.Application.User.RegisterUser;

public class RegisterUserValidator : AbstractValidator<CreateUserRequest>
{
    public RegisterUserValidator()
    {
        RuleFor(x => x.Email).NotEmpty().WithMessage("Email is required!"); ;
        RuleFor(x => x.UserName).NotEmpty().WithMessage("Username is required!"); ;
        RuleFor(x => x.PhoneNumber).NotEmpty().WithMessage("Phone number is required!");
        RuleFor(model => model.Password)
           .NotEmpty().WithMessage("Password is required!")
           .Equal(model => model.RepeatPassword).WithMessage("Passwords do not match!");
        RuleFor(model => model.RepeatPassword)
            .NotEmpty().WithMessage("Repeat password is required!");
    }
}
