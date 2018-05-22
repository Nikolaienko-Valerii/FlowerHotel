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
    public class HotelService : IHotelService
    {
        IUnitOfWork Database { get; set; }

        public HotelService(IUnitOfWork uow)
        {
            Database = uow;
        }
        public async Task Create(HotelDTO hotelDto)
        {
            Hotel hotel = new Hotel();
            hotel.Name = hotelDto.Name;
            hotel.Location = hotelDto.Location;
            hotel.AmountOfPlaces = hotelDto.AmountOfPlaces;
            hotel.PlacesAvailable = hotelDto.AmountOfPlaces;
            Database.Hotels.Create(hotel);
            await Database.SaveAsync();
        }
        public async Task Update(HotelDTO hotelDto)
        {
            Hotel hotel = new Hotel();
            hotel.Id = hotelDto.Id;
            hotel.Name = hotelDto.Name;
            hotel.Location = hotelDto.Location;
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
            var result = new HotelDTO();
            result.Id = hotel.Id;
            result.Name = hotel.Name;
            result.Location = hotel.Location;
            result.PlacesAvailable = hotel.PlacesAvailable;
            result.AmountOfPlaces = hotel.AmountOfPlaces;
            return result;
        }
        public void Dispose()
        {
            Database.Dispose();
        }
    }
}
