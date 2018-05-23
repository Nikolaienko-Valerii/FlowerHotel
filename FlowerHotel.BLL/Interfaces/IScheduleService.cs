using FlowerHotel.BLL.DTO.Entities;
using FlowerHotel.BLL.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;
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
    }
}
