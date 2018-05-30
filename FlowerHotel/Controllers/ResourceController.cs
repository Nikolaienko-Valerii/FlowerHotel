using System.Web.Http;
using FlowerHotel.BLL.Interfaces;
using FlowerHotel.BLL.DTO;
using FlowerHotel.BLL.Services;
using FlowerHotel.Models;
using System.Threading.Tasks;

namespace FlowerHotel.Controllers
{
    [Authorize(Roles ="admin")]
    public class ResourceController : ApiController
    {
        private IResourceService ResourceService
        {
            get
            {
                return new ServiceCreator().CreateResourceService("DefaultConnection");
            }
        }

        // GET: api/Resource
        public IHttpActionResult Get()
        {
            return Ok(ResourceService.GetAll());
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
            var resourceDTO = new ResourceDTO
            {
                Name = resource.Name,
                Measure = resource.Measure
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
            var resourceDTO = new ResourceDTO
            {
                Name = resource.Name,
                Measure = resource.Measure
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
