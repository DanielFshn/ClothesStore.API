namespace ClothesStrore.Application.User.Dtos;

public record TokenResponseDto(string Token, string RefreshToken, DateTime RefreshTokenExpiration);
