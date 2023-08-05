using ClothesStore.Domain.Common;
using Microsoft.AspNet.Identity.EntityFramework;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClothesStore.Domain.Entities
{
    public class ShippingAdress : BaseEntity
    {
        public Guid UserId { get; set; }
        [ForeignKey("UserId")]
        public IdentityUser User { get; set; }
        public Guid AdressDetailsId { get; set; }
        [ForeignKey("AdressDetailsId")]
        public AdressDetail AdressDetail { get; set; }
    }
}
