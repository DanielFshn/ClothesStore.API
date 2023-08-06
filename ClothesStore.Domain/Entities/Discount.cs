using ClothesStore.Domain.Common;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection.Metadata.Ecma335;

namespace ClothesStore.Domain.Entities
{
    public class Discount : BaseEntity
    {
        public string ProductId { get; set; }
        [ForeignKey("ProductId")]
        public Product Product { get; set; }
        public int DiscountAmount { get; set; }
    }
}
