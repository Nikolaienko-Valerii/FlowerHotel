using AutoMapper;
using FlowerHotel.BLL.DTO;
using FlowerHotel.BLL.Interfaces;
using FlowerHotel.DAL.Entities;
using FlowerHotel.DAL.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FlowerHotel.BLL.Services
{
    public class OrderService : IOrderService
    {
        IUnitOfWork Database { get; }

        public OrderService(IUnitOfWork uow)
        {
            Database = uow;
        }
        public async Task Create(OrderDTO orderDto)
        {
            var order = new Order
            {
                HotelId = orderDto.HotelId,
                ApplicationUserId = orderDto.ApplicationUserId,
                PlantId = orderDto.PlantId,
                StartTime = orderDto.StartTime,
                EndTime = orderDto.EndTime,
                IsActive = orderDto.IsActive
            };
            Database.Orders.Create(order);
            await Database.SaveAsync();
        }
        public async Task Update(OrderDTO orderDto)
        {
            var order = new Order
            {
                Id = orderDto.Id,
                HotelId = orderDto.HotelId,
                ApplicationUserId = orderDto.ApplicationUserId,
                PlantId = orderDto.PlantId,
                StartTime = orderDto.StartTime,
                EndTime = orderDto.EndTime,
                IsActive = orderDto.IsActive
            };
            Database.Orders.Update(order);
            await Database.SaveAsync();
        }
        public async Task Delete(int orderId)
        {
            Database.Orders.Delete(orderId);
            await Database.SaveAsync();
        }
        public IEnumerable<OrderDTO> GetAll()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Order, OrderDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<Order>, List<OrderDTO>>(Database.Orders.GetAll());
        }
        public OrderDTO Get(int orderId)
        {
            var order = Database.Orders.Get(orderId);
            var result = new OrderDTO
            {
                Id = order.Id,
                HotelId = order.HotelId,
                ApplicationUserId = order.ApplicationUserId,
                PlantId = order.PlantId,
                StartTime = order.StartTime,
                EndTime = order.EndTime,
                IsActive = order.IsActive
            };
            return result;
        }

        public IEnumerable<OrderDTO> GetUserOrders(string userId)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Order, OrderDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<Order>, List<OrderDTO>>(Database.Orders.Find(o => o.ApplicationUserId == userId));
        }
        public void Dispose()
        {
            Database.Dispose();
        }
    }
}
