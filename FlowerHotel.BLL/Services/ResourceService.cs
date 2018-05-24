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
    public class ResourceService : IResourceService
    {
        IUnitOfWork Database { get; set; }

        public ResourceService(IUnitOfWork uow)
        {
            Database = uow;
        }
        public async Task Create(ResourceDTO resourceDto)
        {
            Resource resource = new Resource();
            resource.Name = resourceDto.Name;
            resource.Amount = resourceDto.Amount;
            resource.HotelId = resource.HotelId;
            resource.Measure = resourceDto.Measure;
            Database.Resources.Create(resource);
            await Database.SaveAsync();
        }
        public async Task Update(ResourceDTO resourceDto)
        {
            Resource resource = new Resource();
            resource.Id = resourceDto.Id;
            resource.Name = resourceDto.Name;
            resource.Amount = resourceDto.Amount;
            resource.HotelId = resource.HotelId;
            resource.Measure = resourceDto.Measure;
            Database.Resources.Update(resource);
            await Database.SaveAsync();
        }
        public async Task Delete(int resourceId)
        {
            Database.Resources.Delete(resourceId);
            await Database.SaveAsync();
        }
        public IEnumerable<ResourceDTO> GetAll()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Resource, ResourceDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<Resource>, List<ResourceDTO>>(Database.Resources.GetAll());
        }
        public ResourceDTO Get(int resourceId)
        {
            var resource = Database.Resources.Get(resourceId);
            var result = new ResourceDTO();
            result.Id = resource.Id;
            result.Name = resource.Name;
            result.Amount = resource.Amount;
            result.Measure = resource.Measure;
            result.HotelId = resource.HotelId;
            return result;
        }
        public IEnumerable<ResourceDTO> GetHotelResources(int hotelId)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Resource, ResourceDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<Resource>, List<ResourceDTO>>(Database.Resources.Find(r => r.HotelId == hotelId));
        }

        public void Dispose()
        {
            Database.Dispose();
        }
    }
}
