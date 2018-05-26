namespace FlowerHotel.DAL.Entities
{
    public class Resource
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int HotelId { get; set; }
        public Hotel Hotel { get; set; }
        public double Amount { get; set; }
        public string Measure { get; set; }
    }
}
