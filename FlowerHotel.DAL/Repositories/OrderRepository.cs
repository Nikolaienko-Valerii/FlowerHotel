using FlowerHotel.DAL.Interfaces;
using FlowerHotel.DAL.Entities;
using System;
using System.Collections.Generic;
using FlowerHotel.DAL.EF;
using System.Data.Entity;
using System.Linq;

namespace FlowerHotel.DAL.Repositories
{
    public class OrderRepository : IRepository<Order>
    {
        private ApplicationContext _db;

        public OrderRepository(ApplicationContext context)
        {
            _db = context;
        }

        public IEnumerable<Order> GetAll()
        {
            return _db.Orders.Include(o => o.Hotel).Include(o => o.Plant).Include(o => o.ApplicationUser);
        }

        public Order Get(int id)
        {
            return _db.Orders.Find(id);
        }

        public void Create(Order order)
        {
            _db.Orders.Add(order);
        }

        public void Update(Order order)
        {
            _db.Entry(order).State = EntityState.Modified;
        }

        public IEnumerable<Order> Find(Func<Order, Boolean> predicate)
        {
            return _db.Orders.Where(predicate).ToList();
        }

        public void Delete(int id)
        {
            Order order = _db.Orders.Find(id);
            if (order != null)
                _db.Orders.Remove(order);
        }
    }
}
