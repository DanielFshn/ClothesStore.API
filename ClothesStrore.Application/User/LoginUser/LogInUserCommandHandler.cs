using ClothesStrore.Application.User.Token;

namespace ClothesStrore.Application.User.LoginUser
{
    public class LogInUserCommandHandler : IRequestHandler<LoginUserRequest, LoginUserResponse>
    {
        public UserManager<IdentityUser> _userManager { get; }
        public SignInManager<IdentityUser> _signInManager { get; }
        public IJwtTokenGenerator _jwtTokenGenerator { get; }

        public LogInUserCommandHandler(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager, IJwtTokenGenerator jwtTokenGenerator)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _jwtTokenGenerator = jwtTokenGenerator;
        }


        public async Task<LoginUserResponse> Handle(LoginUserRequest request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByNameAsync(request.Username);
            if (user != null)
            {
                var result = await _signInManager.CheckPasswordSignInAsync(user, request.Password, lockoutOnFailure: false);
                if (result.Succeeded)
                {
                    var token = await _jwtTokenGenerator.GenerateToken(user);
                    return new LoginUserResponse { IsSuccesful = true, Token = token };
                }
            }
            return new LoginUserResponse { IsSuccesful = false };
        }
    }
}
