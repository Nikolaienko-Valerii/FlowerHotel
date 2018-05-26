using System.ComponentModel.DataAnnotations;
using System;

namespace FlowerHotel.Models
{
    public class OrderModel
    {
        public int Id { get; set; }
        public string ApplicationUserId { get; set; }
        [Required]
        public int PlantId { get; set; }
        [Required]
        public DateTime StartTime { get; set; }
        [Required]
        public DateTime EndTime { get; set; }
        [Required]
        public int HotelId { get; set; }
        public bool IsActive { get; set; }
    }
}