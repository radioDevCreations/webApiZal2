using Domain.Common;

namespace Domain.Entities
{
    public class Harbour : BaseEntity
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public string Street { get; set; }
        public string StreetNumber { get; set; }
        public string City { get; set; }
        public string ZipCode { get; set; }
        public string Country { get; set; }
        public ICollection<Rental> Rentals { get; set; }
        public ICollection<Boat> Boats { get; set; }
    }
}
