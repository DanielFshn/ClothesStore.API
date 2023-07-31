

namespace ClothesStrore.Application.Context
{
    public interface IMyDbContext
    {
        Task<int> SaveToDbAsync();
    }
}
