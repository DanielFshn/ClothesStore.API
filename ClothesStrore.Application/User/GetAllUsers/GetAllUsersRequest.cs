using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClothesStrore.Application.User.GetAllUsers
{
    public class GetAllUsersRequest : IRequest<List<GetAllUsersResponse>>
    {
    }
}
