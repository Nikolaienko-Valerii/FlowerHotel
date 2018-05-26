using System.ComponentModel.DataAnnotations;

namespace FlowerHotel.Models
{
    public class ResourceModel
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public int HotelId { get; set; }
        [Required]
        public double Amount { get; set; }
        [Required]
        public string Measure { get; set; }
    }
}