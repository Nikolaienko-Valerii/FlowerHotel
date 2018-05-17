using System;
using System.Collections.Generic;
using System.Text;

namespace FlowerHotel.DAL.Entities
{
    class Order
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public int PlantId { get; set; }
        public Plant Plant { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public int HotelId { get; set; }
        public Hotel Hotel { get; set; }
        public bool IsActive { get; set; }
    }
}
