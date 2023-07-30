using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClothesStrore.Application.User.LoginUser
{
    public class LoginUserRequest : IRequest<LoginUserResponse>
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
