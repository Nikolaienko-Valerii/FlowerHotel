using FlowerHotel.DAL.Interfaces;
using FlowerHotel.DAL.Entities;
using System;
using System.Collections.Generic;
using FlowerHotel.DAL.EF;
using System.Data.Entity;
using System.Linq;

namespace FlowerHotel.DAL.Repositories
{
    public class ScheduleRepository : IRepository<Schedule>
    {
        private ApplicationContext _db;

        public ScheduleRepository(ApplicationContext context)
        {
            _db = context;
        }

        public IEnumerable<Schedule> GetAll()
        {
            return _db.Schedules.Include(s => s.Plant).Include(s => s.Resource);
        }

        public Schedule Get(int id)
        {
            return _db.Schedules.Find(id);
        }

        public void Create(Schedule schedule)
        {
            _db.Schedules.Add(schedule);
        }

        public void Update(Schedule schedule)
        {
            _db.Entry(schedule).State = EntityState.Modified;
        }

        public IEnumerable<Schedule> Find(Func<Schedule, Boolean> predicate)
        {
            return _db.Schedules.Where(predicate).ToList();
        }

        public void Delete(int id)
        {
            Schedule schedule = _db.Schedules.Find(id);
            if (schedule != null)
                _db.Schedules.Remove(schedule);
        }
    }
}
