using AutoMapper;
using FlowerHotel.BLL.DTO;
using FlowerHotel.BLL.Interfaces;
using FlowerHotel.DAL.Entities;
using FlowerHotel.DAL.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FlowerHotel.BLL.Services
{
    public class HotelService : IHotelService
    {
        IUnitOfWork Database { get; }

        public HotelService(IUnitOfWork uow)
        {
            Database = uow;
        }
        public async Task Create(HotelDTO hotelDto)
        {
            var hotel = new Hotel
            {
                Name = hotelDto.Name,
                Location = hotelDto.Location,
                AmountOfPlaces = hotelDto.AmountOfPlaces,
                PlacesAvailable = hotelDto.AmountOfPlaces
            };
            Database.Hotels.Create(hotel);
            await Database.SaveAsync();
        }
        public async Task Update(HotelDTO hotelDto)
        {
            var hotel = new Hotel
            {
                Id = hotelDto.Id,
                Name = hotelDto.Name,
                Location = hotelDto.Location
            };
            int available = hotelDto.AmountOfPlaces - (hotel.AmountOfPlaces - hotel.PlacesAvailable);
            hotel.AmountOfPlaces = hotelDto.AmountOfPlaces;
            hotel.PlacesAvailable = available;
            Database.Hotels.Update(hotel);
            await Database.SaveAsync();
        }
        public async Task Delete(int hotelId)
        {
            Database.Hotels.Delete(hotelId);
            await Database.SaveAsync();
        }
        public IEnumerable<HotelDTO> GetAll()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Hotel, HotelDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<Hotel>, List<HotelDTO>>(Database.Hotels.GetAll());
        }
        public HotelDTO Get(int hotelId)
        {
            var hotel = Database.Hotels.Get(hotelId);
            var result = new HotelDTO
            {
                Id = hotel.Id,
                Name = hotel.Name,
                Location = hotel.Location,
                PlacesAvailable = hotel.PlacesAvailable,
                AmountOfPlaces = hotel.AmountOfPlaces
            };
            return result;
        }
        public void Dispose()
        {
            Database.Dispose();
        }
    }
}
