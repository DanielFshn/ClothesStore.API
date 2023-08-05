using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClothesStrore.Application.User.Token
{
    public interface IJwtTokenGenerator
    {
        Task<string> GenerateToken(IdentityUser user);
    }
}
