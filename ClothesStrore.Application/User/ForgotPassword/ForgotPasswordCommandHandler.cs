using ClothesStrore.Application.Common.Email;

namespace ClothesStrore.Application.User.ForgotPassword;

public class ForgotPasswordCommandHandler : IRequestHandler<EmailSendRequest, string>
{
    public IMapper _mapper { get; }
    public IEmailService _emailService { get; }
    public UserManager<IdentityUser> _userManager { get; }
    public ForgotPasswordCommandHandler(IMapper mapper, IEmailService emailService, UserManager<IdentityUser> userManager)
    {
        _emailService = emailService;
        _userManager = userManager;
        _mapper = mapper;
    }

    public async Task<string> Handle(EmailSendRequest request, CancellationToken cancellationToken)
    {
        var user = await _userManager.FindByEmailAsync(request.Email);
        if (user != null)
        {
            var token = await _userManager.GeneratePasswordResetTokenAsync(user);
            //duket te formohet url ne baze te front end
            var resetLink = $"http://localhost:3000/resetPassword?email={user.Email}&token={token}";
            var emailResponse = _mapper.Map<EmailSendResponse>(request);
            emailResponse.Body = "<p>Click here to reset your password</p>";
            emailResponse.Subject = resetLink;
            // Send reset link to user's email
            await _emailService.SendEmail(emailResponse);
            return JsonConvert.SerializeObject(emailResponse);
        }
        return JsonConvert.SerializeObject(new { Message = "User with this email doesn't exist!" });

    }
}
