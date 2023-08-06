using ClothesStore.Domain.Common;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;


namespace ClothesStore.Domain.Entities
{
    public class ProductRating : BaseEntity
    {
        public string ProductId { get; set; }
        [ForeignKey("ProductId")]
        public Product Product { get; set; }
        public string UserId { get; set; }
        [ForeignKey("UserId")]
        public IdentityUser User { get; set; }
        public int RatingNumber { get; set; }
        public string Title { get; set; }
        public string Comments { get; set; }
    }
}
