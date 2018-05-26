using FlowerHotel.BLL.DTO;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FlowerHotel.BLL.Interfaces
{
    public interface IScheduleService : IDisposable
    {
        Task Create(ScheduleDTO scheduleDto);
        Task Update(ScheduleDTO scheduleDto);
        Task Delete(int scheduleId);
        IEnumerable<ScheduleDTO> GetAll();
        ScheduleDTO Get(int scheduleId);
        IEnumerable<ScheduleDTO> GetPlantSchedules(int plantId);
        IEnumerable<ScheduleDTO> GetSchedulesForToday();
    }
}
