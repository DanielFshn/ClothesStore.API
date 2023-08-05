using ClothesStore.Domain.Common;
using Microsoft.AspNet.Identity.EntityFramework;

namespace ClothesStore.Domain.Entities
{
    public class Order : BaseEntity
    {
        public Guid UserId { get; set; }
        public IdentityUser User { get; set; }
        public decimal TotalAmount { get; set; }
    }
}
