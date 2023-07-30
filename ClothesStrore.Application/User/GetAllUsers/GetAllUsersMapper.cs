using AutoMapper;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClothesStrore.Application.User.GetAllUsers
{
    public class GetAllUsersMapper : Profile
    {
        public GetAllUsersMapper()
        {
            CreateMap<IdentityUser, GetAllUsersResponse>();     
        }
    }
}
