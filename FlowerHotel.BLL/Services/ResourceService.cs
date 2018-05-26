using AutoMapper;
using FlowerHotel.BLL.DTO;
using FlowerHotel.BLL.Interfaces;
using FlowerHotel.DAL.Entities;
using FlowerHotel.DAL.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FlowerHotel.BLL.Services
{
    public class ResourceService : IResourceService
    {
        private IUnitOfWork Database { get; }

        public ResourceService(IUnitOfWork uow)
        {
            Database = uow;
        }
        public async Task Create(ResourceDTO resourceDto)
        {
            var resource = new Resource
            {
                Name = resourceDto.Name,
                Amount = resourceDto.Amount
            };
            resource.HotelId = resource.HotelId;
            resource.Measure = resourceDto.Measure;
            Database.Resources.Create(resource);
            await Database.SaveAsync();
        }
        public async Task Update(ResourceDTO resourceDto)
        {
            var resource = new Resource
            {
                Id = resourceDto.Id,
                Name = resourceDto.Name,
                Amount = resourceDto.Amount
            };
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
            var result = new ResourceDTO
            {
                Id = resource.Id,
                Name = resource.Name,
                Amount = resource.Amount,
                Measure = resource.Measure,
                HotelId = resource.HotelId
            };
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
