using System;
using System.Collections.Generic;
using System.Text;

namespace FlowerHotel.BLL.DTO.Entities
{
    public class OrderDTO
    {
        public int Id { get; set; }
        public int ApplicationUserId { get; set; }
        public int PlantId { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public int HotelId { get; set; }
        public bool IsActive { get; set; }
    }
}
