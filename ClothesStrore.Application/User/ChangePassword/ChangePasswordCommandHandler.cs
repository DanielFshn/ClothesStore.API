using Newtonsoft.Json;

namespace ClothesStrore.Application.User.ChangePassword
{
    public class ChangePasswordCommandHandler : IRequestHandler<ChangePasswordRequest, string>
    {
        public IMapper _mapper { get; }
        public UserManager<IdentityUser> _userManager { get; }
        public ChangePasswordCommandHandler(IMapper mapper, UserManager<IdentityUser> userManager)
        {
            _mapper = mapper;
            _userManager = userManager;
        }


        public async Task<string> Handle(ChangePasswordRequest request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByIdAsync(request.Id);
            if (user == null)
                return JsonConvert.SerializeObject(new { Message = "false" });

            var result = await _userManager.ChangePasswordAsync(user, request.CurrentPassword, request.NewPassword);
            bool succeeded = result.Succeeded;
            return JsonConvert.SerializeObject(new { Message = succeeded });
        }
    }
}
