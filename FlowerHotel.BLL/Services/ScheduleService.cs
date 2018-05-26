using System;
using AutoMapper;
using FlowerHotel.BLL.DTO;
using FlowerHotel.BLL.Interfaces;
using FlowerHotel.DAL.Entities;
using FlowerHotel.DAL.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FlowerHotel.BLL.Services
{
    public class ScheduleService : IScheduleService
    {
        private IUnitOfWork Database { get; }

        public ScheduleService(IUnitOfWork uow)
        {
            Database = uow;
        }
        public async Task Create(ScheduleDTO scheduleDto)
        {
            var schedule = new Schedule
            {
                PlantId = scheduleDto.PlantId,
                ResourceId = scheduleDto.ResourceId,
                IsTracked = scheduleDto.IsTracked,
                Interval = scheduleDto.Interval,
                LastTimeDone = scheduleDto.LastTimeDone,
                Amount = scheduleDto.Amount,
                Measure = scheduleDto.Measure
            };
            Database.Schedules.Create(schedule);
            await Database.SaveAsync();
        }
        public async Task Update(ScheduleDTO scheduleDto)
        {
            var schedule = new Schedule
            {
                Id = scheduleDto.Id,
                PlantId = scheduleDto.PlantId,
                ResourceId = scheduleDto.ResourceId,
                IsTracked = scheduleDto.IsTracked,
                Interval = scheduleDto.Interval,
                LastTimeDone = scheduleDto.LastTimeDone,
                Amount = scheduleDto.Amount,
                Measure = scheduleDto.Measure
            };
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
            var result = new ScheduleDTO
            {
                Id = schedule.Id,
                PlantId = schedule.PlantId,
                ResourceId = schedule.ResourceId,
                IsTracked = schedule.IsTracked,
                Interval = schedule.Interval,
                LastTimeDone = schedule.LastTimeDone,
                Amount = schedule.Amount,
                Measure = schedule.Measure
            };
            return result;
        }
        public IEnumerable<ScheduleDTO> GetPlantSchedules(int plantId)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Schedule, ScheduleDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<Schedule>, List<ScheduleDTO>>(Database.Schedules.Find(s => s.PlantId == plantId));
        }
        public IEnumerable<ScheduleDTO> GetSchedulesForToday()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Schedule, ScheduleDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<Schedule>, List<ScheduleDTO>>(Database.Schedules.Find(s => (s.LastTimeDone.AddDays(s.Interval).Date == DateTime.Today.Date)));
        }
        public void Dispose()
        {
            Database.Dispose();
        }
    }
}
