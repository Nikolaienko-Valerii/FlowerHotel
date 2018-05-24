using AutoMapper;
using FlowerHotel.BLL.DTO.Entities;
using FlowerHotel.BLL.Infrastructure;
using FlowerHotel.BLL.Interfaces;
using FlowerHotel.DAL.Entities;
using FlowerHotel.DAL.Interfaces;
using FlowerHotel.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlowerHotel.BLL.Services
{
    public class PlantService : IPlantService
    {
        IUnitOfWork Database { get; set; }

        public PlantService(IUnitOfWork uow)
        {
            Database = uow;
        }
        public async Task Create(PlantDTO plantDto)
        {
            Plant plant = new Plant();
            plant.Name = plantDto.Name;
            plant.ApplicationUserId = plantDto.ApplicationUserId;
            Database.Plants.Create(plant);
            await Database.SaveAsync();
        }
        public async Task Update(PlantDTO plantDto)
        {
            Plant plant = new Plant();
            plant.Id = plantDto.Id;
            plant.Name = plantDto.Name;
            plant.ApplicationUserId = plantDto.ApplicationUserId;
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
            var result = new PlantDTO();
            result.Id = plant.Id;
            result.Name = plant.Name;
            result.ApplicationUserId = plant.ApplicationUserId;
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
