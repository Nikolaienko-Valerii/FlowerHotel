using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace FlowerHotel.Models
{
    public class HotelModel
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Location { get; set; }
        [Required]
        public int AmmountOfPlaces { get; set; }
        public int PlacesAvailable { get; set; }
    }
}