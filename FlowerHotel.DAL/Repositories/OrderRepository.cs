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
    public class OrderRepository : IRepository<Order>
    {
        private ApplicationContext db;

        public OrderRepository(ApplicationContext context)
        {
            this.db = context;
        }

        public IEnumerable<Order> GetAll()
        {
            return db.Orders.Include(o => o.Hotel).Include(o => o.Plant).Include(o => o.User);
        }

        public Order Get(int id)
        {
            return db.Orders.Find(id);
        }

        public void Create(Order order)
        {
            db.Orders.Add(order);
        }

        public void Update(Order order)
        {
            db.Entry(order).State = EntityState.Modified;
        }

        public IEnumerable<Order> Find(Func<Order, Boolean> predicate)
        {
            return db.Orders.Where(predicate).ToList();
        }

        public void Delete(int id)
        {
            Order Order = db.Orders.Find(id);
            if (Order != null)
                db.Orders.Remove(Order);
        }
    }
}
