using AutoMapper;
using AutoMapper.QueryableExtensions;
using ClothesStrore.Application.Common;
using ClothesStrore.Application.Common.Email;
using ClothesStrore.Application.Common.Exceptions;
using ClothesStrore.Application.Context;
using ClothesStrore.Application.User;
using ClothesStrore.Application.User.ChangePassword;
using ClothesStrore.Application.User.CreaeteUser;
using ClothesStrore.Application.User.ForgotPassword;
using ClothesStrore.Application.User.GetAllUsers;
using ClothesStrore.Application.User.LoginUser;
using ClothesStrore.Application.User.ResetPasswordWithToken;
using ClothesStrore.Application.User.Token;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace ClothesStore.Infrastructure.Auth.Users
{
    internal class UserService : IUserService
    {
        public IMapper _mapper { get; }
        public IMyDbContext _context { get; }
        public UserManager<IdentityUser> _userManager { get; }
        public IEmailService _emailService { get; }
        public SignInManager<IdentityUser> _signInManager { get; }
        public IJwtTokenGenerator _jwtTokenGenerator { get; }
        public RoleManager<IdentityRole> _roleManager { get; }


        public UserService(IMapper mapper, IMyDbContext context, UserManager<IdentityUser> userManager, 
            IEmailService service, SignInManager<IdentityUser> signInManager,IJwtTokenGenerator jwtTokenGenerator, 
            RoleManager<IdentityRole> roleManager) =>
            (_mapper, _context, _userManager, _emailService,_signInManager,_jwtTokenGenerator,_roleManager) = 
            (mapper, context, userManager, service,signInManager,jwtTokenGenerator,roleManager);

        public async Task<List<GetAllUsersResponse>> GetUsersAsync(GetAllUsersRequest request, CancellationToken cancellationToken) =>
            await _userManager.Users.ProjectTo<GetAllUsersResponse>(_mapper.ConfigurationProvider).ToListAsync(cancellationToken);
        

        public async Task<string> ForgotPasswordAsync(EmailSendRequest request, CancellationToken cancellationToken)
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

        public async Task<string> ChangePasswordAsync(ChangePasswordRequest request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByIdAsync(request.Id);
            if (user == null)
                return JsonConvert.SerializeObject(new { Message = "false" });

            var result = await _userManager.ChangePasswordAsync(user, request.CurrentPassword, request.NewPassword);
            bool succeeded = result.Succeeded;
            if (succeeded == false)
            {
                List<IdentityError> errorList = result.Errors.ToList();
                throw new ConflictException(string.Join(", ", errorList.Select(e => e.Description)));
            }
            return JsonConvert.SerializeObject(new { Message = succeeded });
        }

        public async Task<LoginUserResponse> LogInAsync(LoginUserRequest request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByNameAsync(request.Username);
            if (user != null)
            {
                var result = await _signInManager.CheckPasswordSignInAsync(user, request.Password, lockoutOnFailure: false);
                if (result.Succeeded)
                {
                    var token = await _jwtTokenGenerator.GenerateTokenAsync(user);
                    return new LoginUserResponse { IsSuccesful = true, Token = token };
                }
            }
            return new LoginUserResponse { IsSuccesful = false };
        }

        public async Task<string> CreateAsync(CreateUserRequest request, CancellationToken cancellationToken)
        {
            var user = _mapper.Map<IdentityUser>(request);
            var exist = await _userManager.FindByEmailAsync(request.Email);
            if (exist == null)
            {
                var roleExist = await _roleManager.RoleExistsAsync("User");
                if (!roleExist)
                {
                    var apiError = new ApiError { Message = "Deshtoi krijimi i userit!", Errors = "Roli i percaktuar nuk ekziston!" };
                    return JsonConvert.SerializeObject(apiError);
                }
                var hashedPassword = _userManager.PasswordHasher.HashPassword(user, request.Password);
                user.PasswordHash = hashedPassword;
                var result = await _userManager.CreateAsync(user);
                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(user, "User");
                    return "{\"Message\":\"Useri u shtua me sukses\"}";
                }
                else
                {
                    var errors = string.Join(", ", result.Errors.Select(error => error.Description));
                    throw new InternalServerError($"Failed to create user! - Error {errors}");
                }
            }
            else
            {
                throw new ConflictException("A user with this email already exist!");
            }
        }

        public async Task<string> ResetPassowrdWithTokenAsync(ResetPasswordRequest request, CancellationToken cancellationToken)
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
}
