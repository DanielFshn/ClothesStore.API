

using ClothesStore.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ClothesStrore.Application.Context
{
    public interface IMyDbContext
    {
        Task<int> SaveToDbAsync();
        DbSet<Category> Categories { get; }
    }
}
