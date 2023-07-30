using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClothesStrore.Application.User.LoginUser
{
    public class LoginUserResponse
    {
        public bool IsSuccesful { get; set; }
        public string Token { get; set; }
    }
}
