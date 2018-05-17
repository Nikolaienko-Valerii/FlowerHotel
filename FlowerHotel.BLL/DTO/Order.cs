using System;
using System.Collections.Generic;
using System.Text;

namespace FlowerHotel.BLL.DTO.Entities
{
    public class Order
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int PlantId { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public int HotelId { get; set; }
        public bool IsActive { get; set; }
    }
}
