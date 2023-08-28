using AutoMapper;
using Microsoft.AspNetCore.Identity;

namespace ClothesStrore.Application.User.CreaeteUser
{
    public class CreateUserMapper : Profile
    {
        public CreateUserMapper()
        {
            CreateMap<CreateUserRequest, IdentityUser>()
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.UserName))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
                .ForMember(dest => dest.PasswordHash, opt => opt.MapFrom(src => src.Password))
                .ForMember(dest => dest.PasswordHash, opt => opt.MapFrom(src => src.RepeatPassword))
                .ForMember(dest => dest.EmailConfirmed , opt => opt.MapFrom(src => true))
                .ForMember(dest => dest.PhoneNumberConfirmed , opt => opt.MapFrom(src => true))
                .ForMember(dest => dest.TwoFactorEnabled , opt => opt.MapFrom(src => false))
                .ForMember(dest => dest.LockoutEnabled , opt => opt.MapFrom(src => true))
                .ForMember(dest => dest.AccessFailedCount , opt => opt.MapFrom(src => 0));
        }
    }
}
