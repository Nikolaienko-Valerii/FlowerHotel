using System;
using System.Collections.Generic;
using System.Text;

namespace FlowerHotel.DAL.Entities
{
    public class Schedule
    {
        public int Id { get; set; }
        public int PlantId { get; set; }
        public Plant Plant { get; set; }
        public int ResourceId { get; set; }
        public Resource Resource { get; set; }
        public int Interval { get; set; }
        public DateTime LastTimeDone { get; set; }
        public double Amount { get; set; }
        public string Measure { get; set; }
        public bool IsTracked { get; set; }
    }
}
