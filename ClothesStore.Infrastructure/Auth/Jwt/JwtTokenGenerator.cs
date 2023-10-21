using ClothesStrore.Application.Common.Exceptions;
using ClothesStrore.Application.User.Dtos;
using ClothesStrore.Application.User.RefreshToken;
using ClothesStrore.Application.User.Token;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace ClothesStore.Infrastructure.Auth.Jwt
{
    internal class JwtTokenGenerator : IJwtTokenGenerator
    {
        public IConfiguration _configuration { get; }
        public UserManager<IdentityUser> _userManager { get; }
        public JwtTokenGenerator(IConfiguration configuration, UserManager<IdentityUser> userManager)
        {
            _configuration = configuration;
            _userManager = userManager;
        }

        public async Task<string> GenerateTokenAsync(IdentityUser user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_configuration["Jwt:Key"]);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
            {
            new Claim(ClaimTypes.NameIdentifier, user.Id),
            new Claim(ClaimTypes.Name, user.UserName),
            new Claim(ClaimTypes.Email,user.Email),
            new Claim(ClaimTypes.MobilePhone,user.PhoneNumber),
            // Add additional claims here if needed
        }),
                Expires = DateTime.UtcNow.AddHours(10),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256),

            };
            var roles = await _userManager.GetRolesAsync(user);
            foreach (var role in roles)
            {
                tokenDescriptor.Subject.AddClaim(new Claim(ClaimTypes.Role, role.ToString()));

            }
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        public async Task<TokenResponseDto> GenerateRefreshTokenAsync(RefreshTokenCommand request, CancellationToken cancellationToken)
        {
            var principal = GetClaimsFromToken(request.accessToken, GetExpiredTokenValidationParams(), true);
            //var user = await _userManager.FindByIdAsync(principal.GetUserId());
            //_ = user ?? throw new NotFoundException("Perdoruesi nuk ekzston");

            //if (user.RefreshToken != request.refreshToken)
            //    throw new UnauthorizedException("Sesionet nuk perputhen");

            //if (user.RefreshTokenExpiration < DateTime.UtcNow)
            //    throw new UnauthorizedException("Tokeni i rifreskimit ka skaduar");

            //return await GenerateTokens(user, cancellationToken);
            return null;
        }
        public async Task<TokenResponseDto> GenerateTokens(IdentityUser user, CancellationToken cancellationToken)
        {

            var accessToken = await GenerateTokenAsync(user);

            var refreshToken = GenerateRefreshToken();

            var updateRefreshTokenResult = await _userManager.UpdateAsync(user);

            if (!updateRefreshTokenResult.Succeeded)
                throw new UnauthorizedException("Identifikimi deshtoi");

            return new TokenResponseDto(accessToken, refreshToken, DateTime.Now.AddDays(10));
        }
        private static string GenerateRefreshToken()
        {
            var randomNumber = new byte[32];
            using (var numGenerator = RandomNumberGenerator.Create())
            {
                numGenerator.GetBytes(randomNumber);
                return Convert.ToBase64String(randomNumber);
            }
        }
        private static ClaimsPrincipal GetClaimsFromToken(string token, TokenValidationParameters validationParameters, bool isSHA256)
        {
            try
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var claimsPrincipal = tokenHandler.ValidateToken(token, validationParameters, out var securityToken);

                if (securityToken is not JwtSecurityToken jwtSecurityToken)
                    throw new UnauthorizedException("Token i pavlefshem");

                if (isSHA256 && !jwtSecurityToken.Header.Alg.Equals(
                SecurityAlgorithms.HmacSha256,
                StringComparison.InvariantCultureIgnoreCase))
                    throw new UnauthorizedException("Verifikimi deshtoi");

                return claimsPrincipal;

            }
            catch (Exception e)
            {
                //possible log here for the actual thrown exception
                throw new UnauthorizedException("Identitet i pavlefshem");
            }
        }
        private TokenValidationParameters GetExpiredTokenValidationParams() =>
                new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"])),
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidIssuer = _configuration["Jwt:Issuer"],
                    ValidAudience = _configuration["Jwt:Audience"],
                    ClockSkew = TimeSpan.Zero,
                    ValidateLifetime = true
                };
    }
}
