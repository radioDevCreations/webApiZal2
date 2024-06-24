namespace Application.Models.Boat
{
    public class UpdateBoat
    {
        public Guid Id { get; set; }
        public string Brand { get; set; }
        public string Type { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
    }
}
