using FlowerHotel.DAL.Interfaces;
using FlowerHotel.DAL.Entities;
using System;
using System.Collections.Generic;
using FlowerHotel.DAL.EF;
using System.Data.Entity;
using System.Linq;

namespace FlowerHotel.DAL.Repositories
{
    public class HotelRepository : IRepository<Hotel>
    {
        private ApplicationContext _db;

        public HotelRepository(ApplicationContext context)
        {
            _db = context;
        }

        public IEnumerable<Hotel> GetAll()
        {
            return _db.Hotels;
        }

        public Hotel Get(int id)
        {
            return _db.Hotels.Find(id);
        }

        public void Create(Hotel hotel)
        {
            _db.Hotels.Add(hotel);
        }

        public void Update(Hotel hotel)
        {
            _db.Entry(hotel).State = EntityState.Modified;
        }

        public IEnumerable<Hotel> Find(Func<Hotel, Boolean> predicate)
        {
            return _db.Hotels.Where(predicate).ToList();
        }

        public void Delete(int id)
        {
            Hotel hotel = _db.Hotels.Find(id);
            if (hotel != null)
                _db.Hotels.Remove(hotel);
        }
    }
}
