using Microsoft.EntityFrameworkCore;

namespace ClothesStrore.Application.Context
{
    public interface IMyDbContext
    {
        Task<int> SaveToDbAsync();
        public DbSet<AdressDetail> Adresses { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Discount> Discounts { get; set; }
        public DbSet<ClothesStore.Domain.Entities.Gender> Genders { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<ClothesStore.Domain.Entities.Product> Products { get; set; }
        public DbSet<ProductRating> ProductRatings { get; set; }
        public DbSet<Size> Sizes { get; set; }
    }
}
