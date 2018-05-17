using System;
using System.Collections.Generic;
using System.Text;

namespace FlowerHotel.BLL.DTO.Entities
{
    public class Hotel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public int AmountOfPlaces { get; set; }
        public int PlacesAvailable { get; set; }
    }
}
