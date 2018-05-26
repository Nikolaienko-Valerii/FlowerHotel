using System.Web.Http;
using FlowerHotel.BLL.Interfaces;
using FlowerHotel.BLL.DTO;
using FlowerHotel.BLL.Services;
using FlowerHotel.Models;
using System.Threading.Tasks;

namespace FlowerHotel.Controllers
{
    [Authorize]
    public class PlantController : ApiController
    {
        private IPlantService PlantService
        {
            get
            {
                return new ServiceCreator().CreatePlantService("DefaultConnection");
            }
        }
        private IUserService UserService
        {
            get
            {
                return new ServiceCreator().CreateUserService("DefaultConnection");
            }
        }

        // GET: api/Plant
        public async Task<IHttpActionResult> Get()
        {
            string userId = await UserService.GetUserId(User.Identity.Name);
            return Ok(PlantService.GetUserPlants(userId));
        }

        // GET: api/Plant/5
        public IHttpActionResult Get(int id)
        {
            return Ok(PlantService.Get(id));
        }

        // POST: api/Plant
        public async Task<IHttpActionResult> Post(PlantModel plant)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var userId = await UserService.GetUserId(User.Identity.Name);
            var plantDTO = new PlantDTO
            {
                Name = plant.Name,
                ApplicationUserId = userId
            };
            await PlantService.Create(plantDTO);
            return Ok();
        }

        // PUT: api/Hotel/5
        public async Task<IHttpActionResult> Put(PlantModel plant)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var userId = await UserService.GetUserId(User.Identity.Name);
            var plantDTO = new PlantDTO
            {
                Id = plant.Id,
                ApplicationUserId = userId,
                Name = plant.Name
            };
            await PlantService.Update(plantDTO);
            return Ok();
        }

        // DELETE: api/Plant/5
        public IHttpActionResult Delete(int id)
        {
            PlantService.Delete(id);
            return Ok();
        }
    }
}
