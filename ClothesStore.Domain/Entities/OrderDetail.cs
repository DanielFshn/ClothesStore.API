using ClothesStore.Domain.Common;
using System.ComponentModel.DataAnnotations.Schema;


namespace ClothesStore.Domain.Entities
{
    public class OrderDetail : BaseEntity
    {
        public string OrderId { get; set; }
        [ForeignKey("OrderId")]
        public Order Order { get; set; }
        public string ProductId { get; set; }
        [ForeignKey("ProductId")]
        public Product Product { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public string AdressId { get; set; }
        [ForeignKey("AdressId")]
        public AdressDetail Adress { get; set; }
    }
}
