using ClothesStore.Domain.Common;
using System.ComponentModel.DataAnnotations.Schema;


namespace ClothesStore.Domain.Entities
{
    public class OrderDetail : BaseEntity
    {
        public Guid OrderId { get; set; }
        [ForeignKey("OrderId")]
        public Order Order { get; set; }
        public Guid ProductId { get; set; }
        [ForeignKey("ProductId")]
        public Product Product { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public Guid ShipingAdressId { get; set; }
        [ForeignKey("ShipingAdressId")]
        public ShippingAdress Adress { get; set; }
    }
}
