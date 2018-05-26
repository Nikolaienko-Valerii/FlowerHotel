using System.Web.Http;
using FlowerHotel.BLL.Interfaces;
using FlowerHotel.BLL.DTO;
using FlowerHotel.BLL.Services;
using FlowerHotel.Models;
using System.Threading.Tasks;

namespace FlowerHotel.Controllers
{
    [Authorize]
    public class OrderController : ApiController
    {
        private IOrderService OrderService
        {
            get
            {
                return new ServiceCreator().CreateOrderService("DefaultConnection");
            }
        }
        private IUserService UserService
        {
            get
            {
                return new ServiceCreator().CreateUserService("DefaultConnection");
            }
        }

        // GET: api/Order
        public async Task<IHttpActionResult> Get()
        {
            var userId = await UserService.GetUserId(User.Identity.Name);
            return Ok(OrderService.GetAll());
        }

        // GET: api/Order/5
        public IHttpActionResult Get(int id)
        {
            return Ok(OrderService.Get(id));
        }

        // POST: api/Order
        public async Task<IHttpActionResult> Post(OrderModel order)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var userId = await UserService.GetUserId(User.Identity.Name);
            var orderDTO = new OrderDTO
            {
                ApplicationUserId = userId,
                HotelId = order.HotelId,
                PlantId = order.PlantId,
                StartTime = order.StartTime,
                EndTime = order.EndTime,
                IsActive = true
            };
            await OrderService.Create(orderDTO);
            return Ok();
        }

        // PUT: api/Hotel/5
        public async Task<IHttpActionResult> Put(OrderModel order)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var userId = await UserService.GetUserId(User.Identity.Name);
            var orderDTO = new OrderDTO
            {
                Id = order.Id,
                ApplicationUserId = order.ApplicationUserId,
                HotelId = order.HotelId,
                PlantId = order.PlantId,
                StartTime = order.StartTime,
                EndTime = order.EndTime,
                IsActive = true
            };
            await OrderService.Update(orderDTO);
            return Ok();
        }

        // DELETE: api/Order/5
        public IHttpActionResult Delete(int id)
        {
            OrderService.Delete(id);
            return Ok();
        }
    }
}
