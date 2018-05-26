namespace FlowerHotel.BLL.Interfaces
{
    public interface IServiceCreator
    {
        IUserService CreateUserService(string connection);
        IHotelService CreateHotelService(string connection);
        IOrderService CreateOrderService(string connection);
        IPlantService CreatePlantService(string connection);
        IResourceService CreateResourceService(string connection);
        IScheduleService CreateScheduleService(string connection);
        IEmployeeService CreateEmployeeService(string connection);
    }
}
