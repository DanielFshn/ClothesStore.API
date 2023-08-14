using ClothesStore.Domain.Entities;
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
        public DbSet<AdressDetail> Adresses { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Discount> Discounts { get; set; }
        public DbSet<Gender> Genders { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductRating> ProductRatings { get; set; }
        public DbSet<Size> Sizes { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Order>()
                  .HasOne(o => o.User)
                  .WithMany()
                  .HasForeignKey(o => o.UserId)
                  .OnDelete(DeleteBehavior.Restrict);
            builder.Entity<OrderDetail>()
                    .HasOne(od => od.Product)
                    .WithMany()
                    .HasForeignKey(od => od.ProductId)
                    .OnDelete(DeleteBehavior.Restrict);
            builder.Entity<OrderDetail>()
                   .HasOne(od => od.Order)
                   .WithMany()
                   .HasForeignKey(od => od.OrderId)
                   .OnDelete(DeleteBehavior.Restrict);
            builder.Entity<OrderDetail>()
                .HasOne(od => od.Adress)
                .WithMany()
                .HasForeignKey(od => od.AdressId)
                .OnDelete(DeleteBehavior.Restrict);
            builder.Entity<Product>().HasOne(c => c.Category).WithMany().HasForeignKey(c => c.CategoryId);
            builder.Entity<Product>().HasOne(g => g.Gender).WithMany().HasForeignKey(g => g.GenderId);
            builder.Entity<Product>().HasOne(s => s.Size).WithMany().HasForeignKey(s => s.SizeId);
            builder.Entity<ProductRating>().HasOne(pr => pr.Product).WithMany().HasForeignKey(pr => pr.ProductId);


            builder.Entity<Discount>()
                .HasOne(x => x.Product)
                .WithMany()
                .HasForeignKey(x => x.ProductId)
                .OnDelete(DeleteBehavior.Restrict);
        }
        public async Task<int> SaveToDbAsync()
        {
            return await SaveChangesAsync();
        }
    }
}
