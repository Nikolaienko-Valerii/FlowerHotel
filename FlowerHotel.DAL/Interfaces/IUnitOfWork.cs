using System;
using System.Collections.Generic;
using System.Text;
using FlowerHotel.DAL.Entities;
using FlowerHotel.DAL.Identity;
using System.Threading.Tasks;

namespace FlowerHotel.DAL.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        ApplicationUserManager UserManager { get; }
        IClientManager ClientManager { get; }
        ApplicationRoleManager RoleManager { get; }
        IRepository<Hotel> Hotels { get; }
        //IRepository<ApplicationUser> Users { get; }
        IRepository<Plant> Plants { get; }
        IRepository<Order> Orders { get; }
        IRepository<Employee> Employees { get; }
        IRepository<Schedule> Schedules { get; }
        IRepository<Resource> Resources { get; }
        Task SaveAsync();
    }
}
