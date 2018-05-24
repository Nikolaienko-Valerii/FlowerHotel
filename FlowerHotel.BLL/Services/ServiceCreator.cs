using FlowerHotel.BLL.Interfaces;
using FlowerHotel.DAL.Repositories;

namespace FlowerHotel.BLL.Services
{
    public class ServiceCreator : IServiceCreator
    {
        public IUserService CreateUserService(string connection)
        {
            return new UserService(new IdentityUnitOfWork(connection));
        }

        public IHotelService CreateHotelService(string connection)
        {
            return new HotelService(new IdentityUnitOfWork(connection));
        }
        public IPlantService CreatePlantService(string connection)
        {
            return new PlantService(new IdentityUnitOfWork(connection));
        }
        public IOrderService CreateOrderService(string connection)
        {
            return new OrderService(new IdentityUnitOfWork(connection));
        }
        public IResourceService CreateResourceService(string connection)
        {
            return new ResourceService(new IdentityUnitOfWork(connection));
        }
        public IScheduleService CreateScheduleService(string connection)
        {
            return new ScheduleService(new IdentityUnitOfWork(connection));
        }
        public IEmployeeService CreateEmployeeService(string connection)
        {
            return new EmployeeService(new IdentityUnitOfWork(connection));
        }
    }
}
