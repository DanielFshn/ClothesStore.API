using FluentValidation;

namespace ClothesStrore.Application.User.RefreshToken;

public class RefreshTokenCommandValidator : AbstractValidator<RefreshTokenCommand>
{
    public RefreshTokenCommandValidator()
    {
        RuleFor(x => x.accessToken)
            .NotEmpty()
            .WithMessage("Tokeni i aksesit nuk mund te jete bosh");

        RuleFor(x => x.refreshToken)
            .NotEmpty()
            .WithMessage("Tokeni i rifreskimit nuk mund te jete bosh");
    }
}
