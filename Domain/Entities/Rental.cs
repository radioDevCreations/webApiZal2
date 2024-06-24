using Domain.Common;

namespace Domain.Entities
{
    public class Rental : BaseEntity
    {
        public DateTime When { get; set; }
        public Guid HarbourId { get; set; }
        public Guid BoatId { get; set; }
    }
}

