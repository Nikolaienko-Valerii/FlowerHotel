using FlowerHotel.DAL.Interfaces;
using FlowerHotel.DAL.Entities;
using System;
using System.Collections.Generic;
using FlowerHotel.DAL.EF;
using System.Data.Entity;
using System.Linq;

namespace FlowerHotel.DAL.Repositories
{
    public class PlantRepository : IRepository<Plant>
    {
        private ApplicationContext _db;

        public PlantRepository(ApplicationContext context)
        {
            _db = context;
        }

        public IEnumerable<Plant> GetAll()
        {
            return _db.Plants.Include(p => p.ApplicationUser);
        }

        public IEnumerable<Plant> GetUserPlants(string userId)
        {
            return _db.Plants.Where(p => p.ApplicationUserId == userId);
        }

        public Plant Get(int id)
        {
            return _db.Plants.Find(id);
        }

        public void Create(Plant plant)
        {
            _db.Plants.Add(plant);
        }

        public void Update(Plant plant)
        {
            _db.Entry(plant).State = EntityState.Modified;
        }

        public IEnumerable<Plant> Find(Func<Plant, Boolean> predicate)
        {
            return _db.Plants.Where(predicate).ToList();
        }

        public void Delete(int id)
        {
            Plant plant = _db.Plants.Find(id);
            if (plant != null)
                _db.Plants.Remove(plant);
        }
    }
}
