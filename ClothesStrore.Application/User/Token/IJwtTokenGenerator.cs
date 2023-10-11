namespace ClothesStrore.Application.User.Token;

public interface IJwtTokenGenerator
{
    Task<string> GenerateTokenAsync(IdentityUser user);
}
