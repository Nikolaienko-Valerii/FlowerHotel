using FlowerHotel.BLL.DTO.Entities;
using FlowerHotel.BLL.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;
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
    }
}
