using ClothesStrore.Application.User.Dtos;

namespace ClothesStrore.Application.User.RefreshToken;

public record RefreshTokenCommand(string accessToken, string refreshToken) : IRequest<TokenResponseDto>;
