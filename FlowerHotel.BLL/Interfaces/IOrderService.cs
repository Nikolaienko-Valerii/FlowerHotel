using FlowerHotel.BLL.DTO;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FlowerHotel.BLL.Interfaces
{
    public interface IOrderService : IDisposable
    {
        Task Create(OrderDTO orderDto);
        Task Update(OrderDTO orderDto);
        Task Delete(int orderId);
        IEnumerable<OrderDTO> GetAll();
        OrderDTO Get(int orderId);
        IEnumerable<OrderDTO> GetUserOrders(string userId);
    }
}
