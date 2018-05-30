using FlowerHotel.DAL.Interfaces;
using FlowerHotel.DAL.Entities;
using System;
using System.Collections.Generic;
using FlowerHotel.DAL.EF;
using System.Data.Entity;
using System.Linq;

namespace FlowerHotel.DAL.Repositories
{
    public class HotelResourceRepository : IRepository<HotelResource>
    {
        private ApplicationContext _db;

        public HotelResourceRepository(ApplicationContext context)
        {
            _db = context;
        }

        public IEnumerable<HotelResource> GetAll()
        {
            return _db.HotelResources;
        }

        public HotelResource Get(int id)
        {
            return _db.HotelResources.Find(id);
        }

        public void Create(HotelResource hotelResource)
        {
            _db.HotelResources.Add(hotelResource);
        }

        public void Update(HotelResource hotelResource)
        {
            _db.Entry(hotelResource).State = EntityState.Modified;
        }

        public IEnumerable<HotelResource> Find(Func<HotelResource, Boolean> predicate)
        {
            return _db.HotelResources.Where(predicate).ToList();
        }

        public void Delete(int id)
        {
            HotelResource hotelResource = _db.HotelResources.Find(id);
            if (hotelResource != null)
                _db.HotelResources.Remove(hotelResource);
        }
    }
}
