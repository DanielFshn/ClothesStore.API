using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClothesStrore.Application.Context
{
    public interface IMyDbContext
    {
        Task<int> SaveToDbAsync();
    }
}
