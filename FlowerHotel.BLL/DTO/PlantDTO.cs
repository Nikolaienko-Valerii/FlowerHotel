using System;
using System.Collections.Generic;
using System.Text;

namespace FlowerHotel.BLL.DTO.Entities
{
    public class PlantDTO
    {
        public int Id { get; set; }
        public int ApplicationUserId { get; set; }
        public string Name { get; set; }
    }
}
