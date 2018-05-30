using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Antlr.Runtime.Tree;

namespace FlowerHotel.Models
{
    public class HotelResourceModel
    {
        public int Id { get; set; }
        public int HotelId { get; set; }
        public int ResourceId { get; set; }
        public double Amount { get; set; }
    }
}