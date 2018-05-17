using FlowerHotel.DAL.EF;
using FlowerHotel.DAL.Entities;
using FlowerHotel.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace FlowerHotel.DAL.Repositories
{
    class EFUnitOfWork
    {
        private ApplicationContext db;
        private HotelRepository hotelRepository;
        private OrderRepository orderRepository;
        private UserRepository userRepository;
        private PlantRepository plantRepository;
        private EmployeeRepository employeeRepository;
        private ScheduleRepository scheduleRepository;
        private ResourceRepository resourceRepository;

        public EFUnitOfWork(string connectionString)
        {
            db = new ApplicationContext(connectionString);
        }
        public IRepository<Hotel> Hotels
        {
            get
            {
                if (hotelRepository == null)
                    hotelRepository = new HotelRepository(db);
                return hotelRepository;
            }
        }

        public IRepository<Order> Orders
        {
            get
            {
                if (orderRepository == null)
                    orderRepository = new OrderRepository(db);
                return orderRepository;
            }
        }
        public IRepository<User> Users
        {
            get
            {
                if (userRepository == null)
                    userRepository = new UserRepository(db);
                return userRepository;
            }
        }
        public IRepository<Plant> Plants
        {
            get
            {
                if (plantRepository == null)
                    plantRepository = new PlantRepository(db);
                return plantRepository;
            }
        }
        public IRepository<Employee> Employees
        {
            get
            {
                if (employeeRepository == null)
                    employeeRepository = new EmployeeRepository(db);
                return employeeRepository;
            }
        }
        public IRepository<Schedule> Schedules
        {
            get
            {
                if (scheduleRepository == null)
                    scheduleRepository = new ScheduleRepository(db);
                return scheduleRepository;
            }
        }
        public IRepository<Resource> Resources
        {
            get
            {
                if (resourceRepository == null)
                    resourceRepository = new ResourceRepository(db);
                return resourceRepository;
            }
        }
        public void Save()
        {
            db.SaveChanges();
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
