using FluentValidation;

namespace ClothesStrore.Application.User.ForgotPassword;

public class EmailSendValidator : AbstractValidator<EmailSendRequest>
{
    public EmailSendValidator()
    {
        RuleFor(x => x.Email).NotEmpty().WithMessage("Email is required!");

    }

}
