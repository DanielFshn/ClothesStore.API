using AutoMapper;
using ClothesStrore.Application.Context;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace ClothesStrore.Application.User.CreaeteUser
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserRequest, string>
    {
        public IMapper _mapper { get; }
        public IMyDbContext _context { get; }
        public UserManager<IdentityUser> _userManager { get; }

        public CreateUserCommandHandler(IMapper mapper, IMyDbContext context, UserManager<IdentityUser> userManager)
        {
            _mapper = mapper;
            _context = context;
            _userManager = userManager;
        }

        public async Task<string> Handle(CreateUserRequest request, CancellationToken cancellationToken)
        {
            var user = _mapper.Map<IdentityUser>(request);
            var exist = await _userManager.FindByEmailAsync(request.Email);
            if (exist == null)
            {
                var hashedPassword = _userManager.PasswordHasher.HashPassword(user, request.Password);
                user.PasswordHash = hashedPassword;
                var result = await _userManager.CreateAsync(user);
                if (result.Succeeded)
                {
                    return "Useri u shtua me sukses";
                }
                else
                {
                    var errors = string.Join(", ", result.Errors.Select(error => error.Description));
                    return $"Deshtoi krijimi i userit! Gabime: {errors}";
                }
            }
            else
            {
                return "Ekziston nje user me kete email!";
            }
        }
    }
}
