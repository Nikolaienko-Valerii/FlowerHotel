using FlowerHotel.BLL.DTO;
using System;
using System.Collections.Generic;
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
