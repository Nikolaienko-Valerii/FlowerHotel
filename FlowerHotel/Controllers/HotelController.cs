using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Security.Claims;
using FlowerHotel.BLL.Interfaces;
using FlowerHotel.BLL.Infrastructure;
using FlowerHotel.BLL.DTO.Entities;
using FlowerHotel.BLL.Services;
using FlowerHotel.Models;

namespace FlowerHotel.Controllers
{
    [Authorize]
    public class HotelController : ApiController
    {
        private IHotelService HotelService
        {
            get
            {
                return new ServiceCreator().CreateHotelService("DefaultConnection");
            }
        }
        // GET: api/Hotel
        public IHttpActionResult Get()
        {
            return Ok(HotelService.GetAll());
        }

        // GET: api/Hotel/5
        public IHttpActionResult Get(int id)
        {
            return Ok(HotelService.Get(id));
        }

        // POST: api/Hotel
        public IHttpActionResult Post(HotelModel hotel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            HotelDTO hotelDTO = new HotelDTO();
            hotelDTO.Name = hotel.Name;
            hotelDTO.Location = hotel.Location;
            hotelDTO.AmountOfPlaces = hotel.AmmountOfPlaces;
            HotelService.Create(hotelDTO);
            return Ok();
        }

        // PUT: api/Hotel/5
        public IHttpActionResult Put(HotelModel hotel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            HotelDTO hotelDTO = new HotelDTO();
            hotelDTO.Id = hotel.Id;
            hotelDTO.Name = hotel.Name;
            hotelDTO.Location = hotel.Location;
            hotelDTO.AmountOfPlaces = hotel.AmmountOfPlaces;
            HotelService.Update(hotelDTO);
            return Ok();
        }

        // DELETE: api/Hotel/5
        public IHttpActionResult Delete(int id)
        {
            HotelService.Delete(id);
            return Ok();
        }
    }
}
