using FlowerHotel.BLL.DTO;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FlowerHotel.BLL.Interfaces
{
    public interface IResourceService : IDisposable
    {
        Task Create(ResourceDTO resourceDto);
        Task Update(ResourceDTO resourceDto);
        Task Delete(int resourceId);
        IEnumerable<ResourceDTO> GetAll();
        ResourceDTO Get(int resourceId);
        IEnumerable<ResourceDTO> GetHotelResources(int hotelId);
    }
}
