using FlowerHotel.DAL.Interfaces;
using FlowerHotel.DAL.Entities;
using System;
using System.Collections.Generic;
using FlowerHotel.DAL.EF;
using System.Text;
using System.Data.Entity;
using System.Linq;

namespace FlowerHotel.DAL.Repositories
{
    public class ScheduleRepository : IRepository<Schedule>
    {
        private ApplicationContext db;

        public ScheduleRepository(ApplicationContext context)
        {
            this.db = context;
        }

        public IEnumerable<Schedule> GetAll()
        {
            return db.Schedules.Include(s => s.Plant).Include(s => s.Resource);
        }

        public Schedule Get(int id)
        {
            return db.Schedules.Find(id);
        }

        public void Create(Schedule schedule)
        {
            db.Schedules.Add(schedule);
        }

        public void Update(Schedule schedule)
        {
            db.Entry(schedule).State = EntityState.Modified;
        }

        public IEnumerable<Schedule> Find(Func<Schedule, Boolean> predicate)
        {
            return db.Schedules.Where(predicate).ToList();
        }

        public void Delete(int id)
        {
            Schedule schedule = db.Schedules.Find(id);
            if (schedule != null)
                db.Schedules.Remove(schedule);
        }
    }
}
