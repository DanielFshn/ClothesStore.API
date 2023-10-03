using ClothesStrore.Application.Common.Exceptions;

namespace ClothesStrore.Application.User.ResetPasswordWithToken;

public class ResetPasswordCommandHandler : IRequestHandler<ResetPasswordRequest, string>
{
    public UserManager<IdentityUser> _userManager { get; }

    public ResetPasswordCommandHandler(UserManager<IdentityUser> userManager)
    {
        _userManager = userManager;
    }


    public async Task<string> Handle(ResetPasswordRequest request, CancellationToken cancellationToken)
    {
        var parseToken = request.Token.Replace(" ", "+");
        var user = await _userManager.FindByEmailAsync(request.Email);
        if (user != null)
        {
            var result = await _userManager.ResetPasswordAsync(user, parseToken, request.NewPassword);
            if (!result.Succeeded)
            {
                List<IdentityError> errorList = result.Errors.ToList();
                throw new Exception(string.Join(", ", errorList.Select(e => e.Description)));
            }
        }
        else
            throw new NotFoundException("User not found.");
        return JsonConvert.SerializeObject(new { Message = "Password is reseted succesfully!" });
    }
}
