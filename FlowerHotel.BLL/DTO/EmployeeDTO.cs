using System;
using System.Collections.Generic;
using System.Text;

namespace FlowerHotel.BLL.DTO.Entities
{
    public class EmployeeDTO
    {
        public int Id { get; set; }
        public string ApplicationUserId { get; set; }
        public int HotelId { get; set; }
    }
}
