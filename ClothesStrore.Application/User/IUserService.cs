using ClothesStrore.Application.User.ChangePassword;
using ClothesStrore.Application.User.CreaeteUser;
using ClothesStrore.Application.User.ForgotPassword;
using ClothesStrore.Application.User.GetAllUsers;
using ClothesStrore.Application.User.LoginUser;
using ClothesStrore.Application.User.ResetPasswordWithToken;

namespace ClothesStrore.Application.User;

public interface IUserService
{
    Task<List<GetAllUsersResponse>> GetUsersAsync(GetAllUsersRequest request, CancellationToken cancellationToken);
    Task<string> ForgotPasswordAsync(EmailSendRequest request, CancellationToken cancellationToken);
    Task<string> ChangePasswordAsync(ChangePasswordRequest request, CancellationToken cancellationToken);
    Task<LoginUserResponse> LogInAsync(LoginUserRequest request, CancellationToken cancellationToken);
    Task<string> CreateAsync(CreateUserRequest request, CancellationToken cancellationToken);
    Task<string> ResetPassowrdWithTokenAsync(ResetPasswordRequest request, CancellationToken cancellationToken);
}
