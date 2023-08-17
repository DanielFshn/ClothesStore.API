using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClothesStrore.Application.Sizes.InsertSizes
{
    public class CreateSizeRequest : IRequest<string>
    {
        public string Name { get; set; }
    }
}
