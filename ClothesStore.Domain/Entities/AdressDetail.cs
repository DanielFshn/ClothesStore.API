using ClothesStore.Domain.Common;
using System.ComponentModel.DataAnnotations;

namespace ClothesStore.Domain.Entities
{
    public class AdressDetail
    {
        [Key]
        public string Id { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string StreetName { get; set; }
        public string PostalCode { get; set; }
    }
}
