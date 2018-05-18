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
    }
}
