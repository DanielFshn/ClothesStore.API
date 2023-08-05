using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClothesStrore.Application.User.LoginUser
{
    public class LoginUserValidator : AbstractValidator<LoginUserRequest>
    {
        public LoginUserValidator()
        {
             RuleFor(x => x.Username).NotEmpty();   
             RuleFor(x => x.Password).NotEmpty();   
        }
    }
}
