using System;
using System.Collections.Generic;
using System.Text;

namespace FlowerHotel.BLL.DTO.Entities
{
    public class ResourceDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int HotelId { get; set; }
        public double Amount { get; set; }
        public string Measure { get; set; }
    }
}
