using AutoMapper;
using FlowerHotel.BLL.DTO;
using FlowerHotel.BLL.Interfaces;
using FlowerHotel.DAL.Entities;
using FlowerHotel.DAL.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FlowerHotel.BLL.Services
{
    public class HotelResourceService : IHotelResourceService
    {
        private IUnitOfWork Database { get; }

        public HotelResourceService(IUnitOfWork uow)
        {
            Database = uow;
        }
        public async Task Create(HotelResourceDTO hotelResourceDto)
        {
            var hotelResource = new HotelResource
            {
                HotelId = hotelResourceDto.HotelId,
                ResourceId = hotelResourceDto.ResourceId,
                Amount = hotelResourceDto.Amount
            };
            Database.HotelResources.Create(hotelResource);
            await Database.SaveAsync();
        }
        public async Task Update(HotelResourceDTO hotelResourceDto)
        {
            double amount = Database.HotelResources.Get(hotelResourceDto.Id).Amount;
            var hotelResource = new HotelResource
            {
                Id = hotelResourceDto.Id,
                HotelId = hotelResourceDto.HotelId,
                ResourceId = hotelResourceDto.ResourceId,
                Amount = amount + hotelResourceDto.Amount
            };
            Database.HotelResources.Update(hotelResource);
            await Database.SaveAsync();
        }
        public async Task Delete(int hotelResourceId)
        {
            Database.HotelResources.Delete(hotelResourceId);
            await Database.SaveAsync();
        }
        public IEnumerable<HotelResourceDTO> GetAll(int hotelId)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<HotelResource, HotelResourceDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<HotelResource>, List<HotelResourceDTO>>(Database.HotelResources.Find(hr => hr.HotelId == hotelId));
        }
        public HotelResourceDTO Get(int hotelResourceId)
        {
            var hotelResource = Database.HotelResources.Get(hotelResourceId);
            var result = new HotelResourceDTO
            {
                Id = hotelResource.Id,
                HotelId = hotelResource.HotelId,
                ResourceId = hotelResource.ResourceId,
                Amount = hotelResource.Amount
            };
            return result;
        }

        public void Dispose()
        {
            Database.Dispose();
        }
    }
}
