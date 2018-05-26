using System.ComponentModel.DataAnnotations;

namespace FlowerHotel.Models
{
    public class PlantModel
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
    }
}