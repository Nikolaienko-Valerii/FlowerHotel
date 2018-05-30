using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlowerHotel.DAL.Entities
{
    public class HotelResource
    {
        public int Id { get; set; }
        public int ResourceId { get; set; }
        public Resource Resource { get; set; }
        public int HotelId { get; set; }
        public Hotel Hotel { get; set; }
        public double Amount { get; set; }
    }
}
