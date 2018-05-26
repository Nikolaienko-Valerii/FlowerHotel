using System.Web.Http;
using FlowerHotel.BLL.Interfaces;
using FlowerHotel.BLL.DTO;
using FlowerHotel.BLL.Services;
using FlowerHotel.Models;
using System.Threading.Tasks;

namespace FlowerHotel.Controllers
{
    [Authorize]
    public class ScheduleController : ApiController
    {
        private IScheduleService ScheduleService => new ServiceCreator().CreateScheduleService("DefaultConnection");

        // GET: api/Schedule
        public IHttpActionResult Get()
        {
            return Ok(ScheduleService.GetSchedulesForToday());
        }

        // GET: api/Schedule/5
        public IHttpActionResult Get(int id)
        {
            return Ok(ScheduleService.GetPlantSchedules(id));
        }

        // POST: api/Schedule
        public async Task<IHttpActionResult> Post(ScheduleModel schedule)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var scheduleDto = new ScheduleDTO
            {
                PlantId = schedule.PlantId,
                ResourceId = schedule.ResourceId,
                Interval = schedule.Interval,
                LastTimeDone = schedule.LastTimeDone,
                Amount = schedule.Amount,
                Measure = schedule.Measure,
                IsTracked = false
            };
            await ScheduleService.Create(scheduleDto);
            return Ok();
        }

        // PUT: api/Schedule/5
        public IHttpActionResult Put(ScheduleModel schedule)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var scheduleDto = new ScheduleDTO
            {
                Id = schedule.Id,
                PlantId = schedule.PlantId,
                ResourceId = schedule.ResourceId,
                Interval = schedule.Interval,
                LastTimeDone = schedule.LastTimeDone,
                Amount = schedule.Amount,
                Measure = schedule.Measure,
                IsTracked = false
            };
            ScheduleService.Update(scheduleDto);
            return Ok();
        }

        // DELETE: api/Schedule/5
        public IHttpActionResult Delete(int id)
        {
            ScheduleService.Delete(id);
            return Ok();
        }
    }
}
