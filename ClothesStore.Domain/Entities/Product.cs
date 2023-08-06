using ClothesStore.Domain.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClothesStore.Domain.Entities
{
    public class Product : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string ImageUrl{ get; set; }
        public bool IsRelease { get; set; }
        public string CategoryId{ get; set; }
        [ForeignKey("CategoryId")]
        public Category Category { get; set; }
        public string GenderId { get; set; }
        [ForeignKey("GenderId")]
        public Gender Gender { get; set; }
        public string SizeId { get; set; }
        [ForeignKey("SizeId")]
        public Size Size { get; set; }
    }
}
