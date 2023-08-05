using ClothesStore.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClothesStore.Domain.Entities
{
    public class Gender : BaseEntity
    {
        public string GenderName { get; set; }
    }
}
