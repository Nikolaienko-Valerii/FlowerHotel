using System;
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
        IRepository<Plant> Plants { get; }
        IRepository<Order> Orders { get; }
        IRepository<Employee> Employees { get; }
        IRepository<Schedule> Schedules { get; }
        IRepository<Resource> Resources { get; }
        IRepository<HotelResource> HotelResources { get; }
        Task SaveAsync();
    }
}
