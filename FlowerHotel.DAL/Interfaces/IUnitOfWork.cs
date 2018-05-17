using System;
using System.Collections.Generic;
using System.Text;
using FlowerHotel.DAL.Entities;

namespace FlowerHotel.DAL.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<Hotel> Hotels { get; }
        IRepository<User> Users { get; }
        IRepository<Plant> Plants { get; }
        IRepository<Order> Orders { get; }
        IRepository<Employee> Eployees { get; }
        IRepository<Schedule> Schedules { get; }
        IRepository<Resource> Resources { get; }
        void Save();
    }
}
