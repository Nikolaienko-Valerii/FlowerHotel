using System;
using System.Collections.Generic;
using System.Text;

namespace FlowerHotel.BLL.DTO.Entities
{
    public class ScheduleDTO
    {
        public int Id { get; set; }
        public int PlantId { get; set; }
        public int ResourceId { get; set; }
        public int Interval { get; set; }
        public DateTime LastTimeDone { get; set; }
        public double Amount { get; set; }
        public string Measure { get; set; }
        public bool IsTracked { get; set; }
    }
}
