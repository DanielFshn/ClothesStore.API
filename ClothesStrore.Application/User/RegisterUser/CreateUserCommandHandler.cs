using AutoMapper;
using ClothesStrore.Application.Common.Exceptions;
using ClothesStrore.Application.Context;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace ClothesStrore.Application.User.CreaeteUser
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserRequest, string>
    {
        public IMapper _mapper { get; }
        public IMyDbContext _context { get; }
        public UserManager<IdentityUser> _userManager { get; }
        public RoleManager<IdentityRole> _roleManager { get; }

        public CreateUserCommandHandler(IMapper mapper, IMyDbContext context, UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _mapper = mapper;
            _context = context;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task<string> Handle(CreateUserRequest request, CancellationToken cancellationToken)
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
                    throw new InternalServerError($"Deshtoi krijimi i userit! - Error {errors}");
                }
            }
            else
            {
                throw new ConflictException("Ekziston nje user me kete email!");
            }
        }
    }
}
