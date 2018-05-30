using System.Web.Http;
using FlowerHotel.BLL.Interfaces;
using FlowerHotel.BLL.DTO;
using FlowerHotel.BLL.Services;
using FlowerHotel.Models;
using System.Threading.Tasks;

namespace FlowerHotel.Controllers
{
    [Authorize(Roles ="employee")]
    public class HotelResourceController : ApiController
    {
        private IHotelResourceService HotelResourceService
        {
            get
            {
                return new ServiceCreator().CreateHotelResourceService("DefaultConnection");
            }
        }

        private IUserService UserService
        {
            get
            {
                return new ServiceCreator().CreateUserService("DefaultConnection");
            }
        }

        private IEmployeeService EmployeeService
        {
            get
            {
                return new ServiceCreator().CreateEmployeeService("DefaultConnection");
            }
        }

        // GET: api/Resource
        public async Task<IHttpActionResult> Get()
        {
            var userId = await UserService.GetUserId(User.Identity.Name);
            var hotelId = EmployeeService.GetEmployeeHotelId(userId);
            return Ok(HotelResourceService.GetAll(hotelId));
        }

        // GET: api/Resource/5
        public IHttpActionResult Get(int id)
        {
            return Ok(HotelResourceService.Get(id));
        }

        // POST: api/Resource
        public async Task<IHttpActionResult> Post(HotelResourceModel hotelResource)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var hotelResourceDTO = new HotelResourceDTO
            {
                HotelId = hotelResource.HotelId,
                ResourceId = hotelResource.ResourceId,
                Amount = hotelResource.Amount
            };
            await HotelResourceService.Create(hotelResourceDTO);
            return Ok();
        }

        // PUT: api/Hotel/5
        public async Task<IHttpActionResult> Put(HotelResourceModel hotelResource)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var hotelResourceDTO = new HotelResourceDTO
            {
                HotelId = hotelResource.HotelId,
                ResourceId = hotelResource.ResourceId,
                Amount = hotelResource.Amount
            };
            await HotelResourceService.Update(hotelResourceDTO);
            return Ok();
        }

        // DELETE: api/Resource/5
        public IHttpActionResult Delete(int id)
        {
            HotelResourceService.Delete(id);
            return Ok();
        }
    }
}
