using FlowerHotel.BLL.DTO;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FlowerHotel.BLL.Interfaces
{
    public interface IPlantService : IDisposable
    {
        Task Create(PlantDTO plantDto);
        Task Update(PlantDTO plantDto);
        Task Delete(int plantId);
        IEnumerable<PlantDTO> GetAll();
        IEnumerable<PlantDTO> GetUserPlants(string userId);
        PlantDTO Get(int plantId);
    }
}
