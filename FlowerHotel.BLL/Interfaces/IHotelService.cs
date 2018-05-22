using FlowerHotel.BLL.DTO.Entities;
using FlowerHotel.BLL.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FlowerHotel.BLL.Interfaces
{
    public interface IHotelService : IDisposable
    {
        Task Create(HotelDTO hotelDto);
        Task Update(HotelDTO hotelDto);
        Task Delete(int hotelId);
        IEnumerable<HotelDTO> GetAll();
        HotelDTO Get(int hotelId);
    }
}
