using FlowerHotel.DAL.EF;
using FlowerHotel.DAL.Entities;
using FlowerHotel.DAL.Identity;
using FlowerHotel.DAL.Interfaces;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FlowerHotel.DAL.Repositories
{
    public class IdentityUnitOfWork : IUnitOfWork
    {
        private ApplicationContext db;

        private ApplicationUserManager userManager;
        private ApplicationRoleManager roleManager;
        private IClientManager clientManager;

        private HotelRepository hotelRepository;
        private OrderRepository orderRepository;
        private PlantRepository plantRepository;
        private EmployeeRepository employeeRepository;
        private ScheduleRepository scheduleRepository;
        private ResourceRepository resourceRepository;

        public IdentityUnitOfWork(string connectionString)
        {
            db = new ApplicationContext(/*connectionString*/);
            userManager = new ApplicationUserManager(new UserStore<ApplicationUser>(db));
            roleManager = new ApplicationRoleManager(new RoleStore<ApplicationRole>(db));
            clientManager = new ClientManager(db);
        }

        public ApplicationUserManager UserManager
        {
            get { return userManager; }
        }

        public IClientManager ClientManager
        {
            get { return clientManager; }
        }

        public ApplicationRoleManager RoleManager
        {
            get { return roleManager; }
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
        //public IRepository<ApplicationUser> Users
        //{
        //    get
        //    {
        //        if (userRepository == null)
        //            userRepository = new UserRepository(db);
        //        return userRepository;
        //    }
        //}
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
        //public void Save()
        //{
        //    db.SaveChanges();
        //}

        public async Task SaveAsync()
        {
            await db.SaveChangesAsync();
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
