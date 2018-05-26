using AutoMapper;
using FlowerHotel.BLL.DTO;
using FlowerHotel.BLL.Interfaces;
using FlowerHotel.DAL.Entities;
using FlowerHotel.DAL.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FlowerHotel.BLL.Services
{
    public class PlantService : IPlantService
    {
        IUnitOfWork Database { get; }

        public PlantService(IUnitOfWork uow)
        {
            Database = uow;
        }
        public async Task Create(PlantDTO plantDto)
        {
            var plant = new Plant
            {
                Name = plantDto.Name,
                ApplicationUserId = plantDto.ApplicationUserId
            };
            Database.Plants.Create(plant);
            await Database.SaveAsync();
        }
        public async Task Update(PlantDTO plantDto)
        {
            var plant = new Plant
            {
                Id = plantDto.Id,
                Name = plantDto.Name,
                ApplicationUserId = plantDto.ApplicationUserId
            };
            Database.Plants.Update(plant);
            await Database.SaveAsync();
        }
        public async Task Delete(int plantId)
        {
            Database.Plants.Delete(plantId);
            await Database.SaveAsync();
        }
        public IEnumerable<PlantDTO> GetAll()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Plant, PlantDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<Plant>, List<PlantDTO>>(Database.Plants.GetAll());
        }
        public PlantDTO Get(int plantId)
        {
            var plant = Database.Plants.Get(plantId);
            var result = new PlantDTO
            {
                Id = plant.Id,
                Name = plant.Name,
                ApplicationUserId = plant.ApplicationUserId
            };
            return result;
        }

        public IEnumerable<PlantDTO> GetUserPlants(string userId)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Plant, PlantDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<Plant>, List<PlantDTO>>(Database.Plants.Find(p => p.ApplicationUserId == userId));
        }

        public void Dispose()
        {
            Database.Dispose();
        }
    }
}
