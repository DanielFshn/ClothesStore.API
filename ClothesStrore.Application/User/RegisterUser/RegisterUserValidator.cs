using ClothesStrore.Application.User.CreaeteUser;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClothesStrore.Application.User.RegisterUser
{
    public class RegisterUserValidator : AbstractValidator<CreateUserRequest>
    {
        public RegisterUserValidator()
        {
            RuleFor(x => x.Email).NotEmpty();
            RuleFor(x => x.EmailConfirmed).NotEmpty();
            RuleFor(x => x.UserName).NotEmpty();
            RuleFor(x => x.PhoneNumber).NotEmpty();
            RuleFor(x => x.PhoneNumberConfirmed).NotEmpty();
            RuleFor(x => x.TwoFactorEnabled).NotEmpty();
            RuleFor(x => x.LockoutEnabled).NotEmpty();
            RuleFor(x => x.Password).NotEmpty();
            RuleFor(x => x.RepeatPassword).NotEmpty();
        }
    }
}
