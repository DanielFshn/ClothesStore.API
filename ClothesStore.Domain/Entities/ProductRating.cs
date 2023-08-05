using ClothesStore.Domain.Common;
using Microsoft.AspNet.Identity.EntityFramework;
using System.ComponentModel.DataAnnotations.Schema;


namespace ClothesStore.Domain.Entities
{
    public class ProductRating : BaseEntity
    {
        public Guid ProductId { get; set; }
        [ForeignKey("ProductId")]
        public Product Product { get; set; }
        public Guid UserId { get; set; }
        [ForeignKey("UserId")]
        public IdentityUser User { get; set; }
        public int RatingNumber { get; set; }
        public string Title { get; set; }
        public string Comments { get; set; }
    }
}
