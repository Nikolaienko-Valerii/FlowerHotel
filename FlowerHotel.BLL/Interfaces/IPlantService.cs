using FlowerHotel.BLL.DTO.Entities;
using FlowerHotel.BLL.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FlowerHotel.BLL.Interfaces
{
    public interface IPlantService : IDisposable
    {
        Task Create(PlantDTO plantDto);
        Task Update(PlantDTO plantDto);
        Task Delete(int plantId);
        IEnumerable<PlantDTO> GetAll();
        IEnumerable<PlantDTO> GetUserPlants(string UserId);
        PlantDTO Get(int plantId);
    }
}
