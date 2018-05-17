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
    public class PlantRepository : IRepository<Plant>
    {
        private ApplicationContext db;

        public PlantRepository(ApplicationContext context)
        {
            this.db = context;
        }

        public IEnumerable<Plant> GetAll()
        {
            return db.Plants;
        }

        public Plant Get(int id)
        {
            return db.Plants.Find(id);
        }

        public void Create(Plant plant)
        {
            db.Plants.Add(plant);
        }

        public void Update(Plant plant)
        {
            db.Entry(plant).State = EntityState.Modified;
        }

        public IEnumerable<Plant> Find(Func<Plant, Boolean> predicate)
        {
            return db.Plants.Where(predicate).ToList();
        }

        public void Delete(int id)
        {
            Plant plant = db.Plants.Find(id);
            if (plant != null)
                db.Plants.Remove(plant);
        }
    }
}
