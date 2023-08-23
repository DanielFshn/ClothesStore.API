using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClothesStrore.Application.User.ForgotPassword
{
    public class EmailSendRequestMapper : Profile
    {
        public EmailSendRequestMapper()
        {
            CreateMap<EmailSendRequest, EmailSendResponse>()
                  .ForMember(dest => dest.To, opt => opt.MapFrom(src => src.Email));
        }
    }
}
