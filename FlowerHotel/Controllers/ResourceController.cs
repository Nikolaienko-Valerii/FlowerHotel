using System.Web.Http;
using FlowerHotel.BLL.Interfaces;
using FlowerHotel.BLL.DTO;
using FlowerHotel.BLL.Services;
using FlowerHotel.Models;
using System.Threading.Tasks;

namespace FlowerHotel.Controllers
{
    [Authorize(Roles ="employee")]
    public class ResourceController : ApiController
    {
        private IResourceService ResourceService
        {
            get
            {
                return new ServiceCreator().CreateResourceService("DefaultConnection");
            }
        }

        private IEmployeeService EmployeeService
        {
            get
            {
                return new ServiceCreator().CreateEmployeeService("DefaultConnection");
            }
        }

        private IUserService UserService
        {
            get
            {
                return new ServiceCreator().CreateUserService("DefaultConnection");
            }
        }

        // GET: api/Resource
        public async Task<IHttpActionResult> Get()
        {
            string userId = await UserService.GetUserId(User.Identity.Name);
            int hotelId = EmployeeService.GetEmployeeHotelId(userId);
            return Ok(ResourceService.GetHotelResources(hotelId));
        }

        // GET: api/Resource/5
        public IHttpActionResult Get(int id)
        {
            return Ok(ResourceService.Get(id));
        }

        // POST: api/Resource
        public async Task<IHttpActionResult> Post(ResourceModel resource)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            string userId = await UserService.GetUserId(User.Identity.Name);
            int hotelId = EmployeeService.GetEmployeeHotelId(userId);
            ResourceDTO resourceDTO = new ResourceDTO
            {
                Name = resource.Name,
                Amount = resource.Amount,
                Measure = resource.Measure,
                HotelId = hotelId
            };
            await ResourceService.Create(resourceDTO);
            return Ok();
        }

        // PUT: api/Hotel/5
        public async Task<IHttpActionResult> Put(ResourceModel resource)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            string userId = await UserService.GetUserId(User.Identity.Name);
            int hotelId = EmployeeService.GetEmployeeHotelId(userId);
            ResourceDTO resourceDTO = new ResourceDTO
            {
                Name = resource.Name,
                Amount = resource.Amount,
                Measure = resource.Measure,
                HotelId = hotelId
            };
            await ResourceService.Update(resourceDTO);
            return Ok();
        }

        // DELETE: api/Resource/5
        public IHttpActionResult Delete(int id)
        {
            ResourceService.Delete(id);
            return Ok();
        }
    }
}
