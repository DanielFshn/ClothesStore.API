namespace ClothesStrore.Application.User.Token;

public interface IJwtTokenGenerator
{
    Task<string> GenerateToken(IdentityUser user);
}
