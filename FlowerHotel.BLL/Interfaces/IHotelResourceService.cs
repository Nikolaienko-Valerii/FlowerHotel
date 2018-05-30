using FlowerHotel.BLL.DTO;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FlowerHotel.BLL.Interfaces
{
    public interface IHotelResourceService : IDisposable
    {
        Task Create(HotelResourceDTO resourceDto);
        Task Update(HotelResourceDTO resourceDto);
        Task Delete(int hotelResourceId);
        IEnumerable<HotelResourceDTO> GetAll(int hotelId);
        HotelResourceDTO Get(int hotelResourceId);
    }
}