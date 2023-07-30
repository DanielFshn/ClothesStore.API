using ClothesStrore.Application.Context;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ClothesStore.Infrastructure.DatabaseContext
{
    public class ClothesStoreDbContext : IdentityDbContext<IdentityUser>, IMyDbContext
    {
        public ClothesStoreDbContext(DbContextOptions<ClothesStoreDbContext> options) : base(options)
        {

        }

        public async Task<int> SaveToDbAsync()
        {
            return await SaveChangesAsync();
        }
    }
}
