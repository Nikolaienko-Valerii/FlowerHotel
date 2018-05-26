namespace FlowerHotel.DAL.Entities
{
    public class Employee
    {
        public int Id { get; set; }
        public string ApplicationUserId { get; set; }
        public ApplicationUser User { get; set; }
        public int HotelId { get; set; }
        public Hotel Hotel { get; set; }
    }
}
