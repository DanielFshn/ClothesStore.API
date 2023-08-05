using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;


namespace ClothesStore.Domain.Common
{
    public abstract class BaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id{ get; set; }
        public DateTime CreatedOn{ get; set; }
        public DateTime? UpdatedOn{ get; set; }
        public DateTime? DeletedOn { get; set; }
    }
}
