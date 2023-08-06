using ClothesStore.Domain.Common;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClothesStore.Domain.Entities
{
    public class Order : BaseEntity
    {
        public string UserId { get; set; }
        [ForeignKey("UserId")]
        public IdentityUser User { get; set; }
        public decimal TotalAmount { get; set; }
    }
}
