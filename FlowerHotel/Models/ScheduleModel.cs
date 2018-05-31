using System.ComponentModel.DataAnnotations;
using System;

namespace FlowerHotel.Models
{
    public class ScheduleModel
    {
        public int Id { get; set; }
        [Required]
        public int PlantId { get; set; }
        [Required]
        public int ResourceId { get; set; }
        [Required]
        public int Interval { get; set; }
        [Required]
        public DateTime LastTimeDone { get; set; }
        [Required]
        public double Amount { get; set; }
        public string Measure { get; set; }
        public bool IsTracked { get; set; }
    }
}