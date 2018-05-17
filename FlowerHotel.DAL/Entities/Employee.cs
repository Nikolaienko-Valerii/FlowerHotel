using System;
using System.Collections.Generic;
using System.Text;

namespace FlowerHotel.DAL.Entities
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public int HotelId { get; set; }
        public Hotel Hotel { get; set; }
    }
}
