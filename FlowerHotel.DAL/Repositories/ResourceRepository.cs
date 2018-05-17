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
    public class ResourceRepository : IRepository<Resource>
    {
        private ApplicationContext db;

        public ResourceRepository(ApplicationContext context)
        {
            this.db = context;
        }

        public IEnumerable<Resource> GetAll()
        {
            return db.Resources.Include(r => r.Hotel);
        }

        public Resource Get(int id)
        {
            return db.Resources.Find(id);
        }

        public void Create(Resource resource)
        {
            db.Resources.Add(resource);
        }

        public void Update(Resource resource)
        {
            db.Entry(resource).State = EntityState.Modified;
        }

        public IEnumerable<Resource> Find(Func<Resource, Boolean> predicate)
        {
            return db.Resources.Where(predicate).ToList();
        }

        public void Delete(int id)
        {
            Resource resource = db.Resources.Find(id);
            if (resource != null)
                db.Resources.Remove(resource);
        }
    }
}
