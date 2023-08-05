using ClothesStore.Domain.Common;

namespace ClothesStore.Domain.Entities
{
    public class AdressDetail : BaseEntity
    {
        public string Country { get; set; }
        public string City { get; set; }
        public string StreetName { get; set; }
        public string PostalCode { get; set; }
    }
}
