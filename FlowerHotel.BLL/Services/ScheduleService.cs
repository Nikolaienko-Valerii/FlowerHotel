using AutoMapper;
using FlowerHotel.BLL.DTO.Entities;
using FlowerHotel.BLL.Infrastructure;
using FlowerHotel.BLL.Interfaces;
using FlowerHotel.DAL.Entities;
using FlowerHotel.DAL.Interfaces;
using FlowerHotel.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlowerHotel.BLL.Services
{
    public class ScheduleService : IScheduleService
    {
        IUnitOfWork Database { get; set; }

        public ScheduleService(IUnitOfWork uow)
        {
            Database = uow;
        }
        public async Task Create(ScheduleDTO scheduleDto)
        {
            Schedule schedule = new Schedule();
            schedule.PlantId = scheduleDto.PlantId;
            schedule.ResourceId = scheduleDto.ResourceId;
            schedule.IsTracked = scheduleDto.IsTracked;
            schedule.Interval = scheduleDto.Interval;
            schedule.LastTimeDone = scheduleDto.LastTimeDone;
            schedule.Amount = scheduleDto.Amount;
            schedule.Measure = scheduleDto.Measure;
            Database.Schedules.Create(schedule);
            await Database.SaveAsync();
        }
        public async Task Update(ScheduleDTO scheduleDto)
        {
            Schedule schedule = new Schedule();
            schedule.Id = scheduleDto.Id;
            schedule.PlantId = scheduleDto.PlantId;
            schedule.ResourceId = scheduleDto.ResourceId;
            schedule.IsTracked = scheduleDto.IsTracked;
            schedule.Interval = scheduleDto.Interval;
            schedule.LastTimeDone = scheduleDto.LastTimeDone;
            schedule.Amount = scheduleDto.Amount;
            schedule.Measure = scheduleDto.Measure;
            Database.Schedules.Update(schedule);
            await Database.SaveAsync();
        }
        public async Task Delete(int scheduleId)
        {
            Database.Schedules.Delete(scheduleId);
            await Database.SaveAsync();
        }
        public IEnumerable<ScheduleDTO> GetAll()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Schedule, ScheduleDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<Schedule>, List<ScheduleDTO>>(Database.Schedules.GetAll());
        }
        public ScheduleDTO Get(int scheduleId)
        {
            var schedule = Database.Schedules.Get(scheduleId);
            var result = new ScheduleDTO();
            result.Id = schedule.Id;
            result.PlantId = schedule.PlantId;
            result.ResourceId = schedule.ResourceId;
            result.IsTracked = schedule.IsTracked;
            result.Interval = schedule.Interval;
            result.LastTimeDone = schedule.LastTimeDone;
            result.Amount = schedule.Amount;
            result.Measure = schedule.Measure;
            return result;
        }

        //TODO Add Get and GetAll methods for one plant and get list of tracked  schedules for today
        public void Dispose()
        {
            Database.Dispose();
        }
    }
}
