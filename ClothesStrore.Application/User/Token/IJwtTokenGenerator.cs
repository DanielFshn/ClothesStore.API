using ClothesStrore.Application.User.Dtos;
using ClothesStrore.Application.User.RefreshToken;

namespace ClothesStrore.Application.User.Token;

public interface IJwtTokenGenerator
{
    Task<string> GenerateTokenAsync(IdentityUser user);
    Task<TokenResponseDto> GenerateRefreshTokenAsync(RefreshTokenCommand request, CancellationToken cancellationToken);
}
