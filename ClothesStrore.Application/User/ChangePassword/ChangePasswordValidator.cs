using FluentValidation;

namespace ClothesStrore.Application.User.ChangePassword
{
    public class ChangePasswordValidator : AbstractValidator<ChangePasswordRequest>
    {
        public ChangePasswordValidator()
        {
            RuleFor(model => model.Id).NotEmpty().WithMessage("Id is required");
            RuleFor(model => model.CurrentPassword).NotEmpty().WithMessage("Old password is required");
            RuleFor(model => model.NewPassword)
            .NotEmpty().WithMessage("Password is required.")
            .Equal(model => model.RepeatPassword).WithMessage("Passwords do not match.");
            RuleFor(model => model.RepeatPassword)
                .NotEmpty().WithMessage("Repeat password is required.");
        }
    }
}
