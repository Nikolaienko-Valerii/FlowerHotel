using FlowerHotel.DAL.Interfaces;
using FlowerHotel.DAL.Entities;
using System;
using System.Collections.Generic;
using FlowerHotel.DAL.EF;
using System.Data.Entity;
using System.Linq;

namespace FlowerHotel.DAL.Repositories
{
    public class ResourceRepository : IRepository<Resource>
    {
        private ApplicationContext _db;

        public ResourceRepository(ApplicationContext context)
        {
            _db = context;
        }

        public IEnumerable<Resource> GetAll()
        {
            return _db.Resources.Include(r => r.Hotel);
        }

        public Resource Get(int id)
        {
            return _db.Resources.Find(id);
        }

        public void Create(Resource resource)
        {
            _db.Resources.Add(resource);
        }

        public void Update(Resource resource)
        {
            _db.Entry(resource).State = EntityState.Modified;
        }

        public IEnumerable<Resource> Find(Func<Resource, Boolean> predicate)
        {
            return _db.Resources.Where(predicate).ToList();
        }

        public void Delete(int id)
        {
            Resource resource = _db.Resources.Find(id);
            if (resource != null)
                _db.Resources.Remove(resource);
        }
    }
}
