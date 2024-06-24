using Domain.Common;

namespace Domain.Entities
{
    public class Boat : BaseEntity
    {
        public string Brand { get; set; }
        public string Type { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }

        public Guid HarbourId { get; set; }
        public Harbour Harbour { get; set; }

        public ICollection<Rental> Rentals { get; set; }
    }
}
