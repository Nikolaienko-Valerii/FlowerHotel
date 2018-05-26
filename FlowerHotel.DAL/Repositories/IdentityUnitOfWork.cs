using FlowerHotel.DAL.EF;
using FlowerHotel.DAL.Entities;
using FlowerHotel.DAL.Identity;
using FlowerHotel.DAL.Interfaces;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Threading.Tasks;

namespace FlowerHotel.DAL.Repositories
{
    public class IdentityUnitOfWork : IUnitOfWork
    {
        private ApplicationContext _db;

        private ApplicationUserManager userManager;
        private ApplicationRoleManager roleManager;
        private IClientManager clientManager;

        private HotelRepository _hotelRepository;
        private OrderRepository _orderRepository;
        private PlantRepository _plantRepository;
        private EmployeeRepository _employeeRepository;
        private ScheduleRepository _scheduleRepository;
        private ResourceRepository _resourceRepository;

        public IdentityUnitOfWork(string connectionString)
        {
            _db = new ApplicationContext(/*connectionString*/);
            userManager = new ApplicationUserManager(new UserStore<ApplicationUser>(_db));
            roleManager = new ApplicationRoleManager(new RoleStore<ApplicationRole>(_db));
            clientManager = new ClientManager(_db);
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
                if (_hotelRepository == null)
                    _hotelRepository = new HotelRepository(_db);
                return _hotelRepository;
            }
        }

        public IRepository<Order> Orders
        {
            get
            {
                if (_orderRepository == null)
                    _orderRepository = new OrderRepository(_db);
                return _orderRepository;
            }
        }
        
        public IRepository<Plant> Plants
        {
            get
            {
                if (_plantRepository == null)
                    _plantRepository = new PlantRepository(_db);
                return _plantRepository;
            }
        }
        public IRepository<Employee> Employees
        {
            get
            {
                if (_employeeRepository == null)
                    _employeeRepository = new EmployeeRepository(_db);
                return _employeeRepository;
            }
        }
        public IRepository<Schedule> Schedules
        {
            get
            {
                if (_scheduleRepository == null)
                    _scheduleRepository = new ScheduleRepository(_db);
                return _scheduleRepository;
            }
        }
        public IRepository<Resource> Resources
        {
            get
            {
                if (_resourceRepository == null)
                    _resourceRepository = new ResourceRepository(_db);
                return _resourceRepository;
            }
        }

        public async Task SaveAsync()
        {
            await _db.SaveChangesAsync();
        }

        private bool _disposed;

        public virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _db.Dispose();
                }
                _disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
