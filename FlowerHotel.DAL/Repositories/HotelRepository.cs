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
    public class HotelRepository : IRepository<Hotel>
    {
        private ApplicationContext db;

        public HotelRepository(ApplicationContext context)
        {
            this.db = context;
        }

        public IEnumerable<Hotel> GetAll()
        {
            return db.Hotels;
        }

        public Hotel Get(int id)
        {
            return db.Hotels.Find(id);
        }

        public void Create(Hotel hotel)
        {
            db.Hotels.Add(hotel);
        }

        public void Update(Hotel hotel)
        {
            db.Entry(hotel).State = EntityState.Modified;
        }

        public IEnumerable<Hotel> Find(Func<Hotel, Boolean> predicate)
        {
            return db.Hotels.Where(predicate).ToList();
        }

        public void Delete(int id)
        {
            Hotel hotel = db.Hotels.Find(id);
            if (hotel != null)
                db.Hotels.Remove(hotel);
        }
    }
}
