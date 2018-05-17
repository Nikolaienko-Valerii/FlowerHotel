using System;
using System.Collections.Generic;
using System.Text;

namespace FlowerHotel.DAL.Entities
{
    class Plant
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public string Name { get; set; }
        public ICollection<Order> Orders { get; set; }
    }
}
