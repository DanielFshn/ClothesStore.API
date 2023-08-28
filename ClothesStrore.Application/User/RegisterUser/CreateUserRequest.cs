namespace ClothesStrore.Application.User.CreaeteUser
{
    public class CreateUserRequest : IRequest<string>
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Password { get; set; }
        public string RepeatPassword { get; set; }
    }
}
