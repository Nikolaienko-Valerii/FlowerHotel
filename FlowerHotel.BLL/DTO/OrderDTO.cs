using System;

namespace FlowerHotel.BLL.DTO
{
    public class OrderDTO
    {
        public int Id { get; set; }
        public string ApplicationUserId { get; set; }
        public int PlantId { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public int HotelId { get; set; }
        public bool IsActive { get; set; }
    }
}
