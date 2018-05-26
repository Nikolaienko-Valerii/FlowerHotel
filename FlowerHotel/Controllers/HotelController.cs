using System.Web.Http;
using FlowerHotel.BLL.Interfaces;
using FlowerHotel.BLL.DTO;
using FlowerHotel.BLL.Services;
using FlowerHotel.Models;

namespace FlowerHotel.Controllers
{
    [Authorize(Roles = "admin")]
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
            var hotelDTO = new HotelDTO
            {
                Name = hotel.Name,
                Location = hotel.Location,
                AmountOfPlaces = hotel.AmmountOfPlaces
            };
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
            var hotelDTO = new HotelDTO
            {
                Id = hotel.Id,
                Name = hotel.Name,
                Location = hotel.Location,
                AmountOfPlaces = hotel.AmmountOfPlaces
            };
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
