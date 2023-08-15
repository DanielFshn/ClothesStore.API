using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClothesStrore.Application.Gender.InsertGender
{
    public class CreateGenderRequest : IRequest<string>
    {
        public string Name { get; set; }
    }
}
