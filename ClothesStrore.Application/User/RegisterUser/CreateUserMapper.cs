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
                .ForMember(dest => dest.PasswordHash, opt => opt.MapFrom(src => src.RepeatPassword));
        }
    }
}
