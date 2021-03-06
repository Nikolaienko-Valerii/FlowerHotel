﻿using System.Collections.Generic;

namespace FlowerHotel.DAL.Entities
{
    public class Hotel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public int AmountOfPlaces { get; set; }
        public int PlacesAvailable { get; set; }
        public ICollection<Order> Orders { get; set; }
        public ICollection<Employee> Employees { get; set; }
        public ICollection<HotelResource> HotelResources { get; set; }
    }
}
