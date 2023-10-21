using ClothesStrore.Application.User.Dtos;
using ClothesStrore.Application.User.Token;

namespace ClothesStrore.Application.User.RefreshToken
{
    public class RefreshTokenCommandHandler : IRequestHandler<RefreshTokenCommand, TokenResponseDto>
    {
        private readonly IJwtTokenGenerator _jwtToken;

        public RefreshTokenCommandHandler(IJwtTokenGenerator jwtToken) =>
            _jwtToken = jwtToken;

        public Task<TokenResponseDto> Handle(RefreshTokenCommand request, CancellationToken cancellationToken) =>
            _jwtToken.GenerateRefreshTokenAsync(request, cancellationToken);
       
    }
}
