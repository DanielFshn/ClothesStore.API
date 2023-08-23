using FluentValidation;

namespace ClothesStrore.Application.User.ResetPasswordWithToken;

public class ResetPasswordValidator : AbstractValidator<ResetPasswordRequest>
{
    public ResetPasswordValidator()
    {
        RuleFor(model => model.Email).NotEmpty().WithMessage("Email is required");
        RuleFor(model => model.Token).NotEmpty().WithMessage("Reset Token is required");
        RuleFor(model => model.NewPassword)
        .NotEmpty().WithMessage("Password is required.")
        .Equal(model => model.RepeatNewPass).WithMessage("Passwords do not match.");
        RuleFor(model => model.RepeatNewPass)
            .NotEmpty().WithMessage("Repeat password is required.");
    }
}
