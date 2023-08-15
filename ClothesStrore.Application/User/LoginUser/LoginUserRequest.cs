
namespace ClothesStrore.Application.User.LoginUser
{
    public class LoginUserRequest : IRequest<LoginUserResponse>
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
