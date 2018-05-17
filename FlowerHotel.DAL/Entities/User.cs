using System;
using System.Collections.Generic;
using System.Text;

namespace FlowerHotel.DAL.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string PhoneNumber { get; set; }
        public ICollection<Plant> Plants { get; set; }
        public ICollection<Order> Orders { get; set; }
    }
}
