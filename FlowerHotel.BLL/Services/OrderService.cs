using AutoMapper;
using FlowerHotel.BLL.DTO.Entities;
using FlowerHotel.BLL.Infrastructure;
using FlowerHotel.BLL.Interfaces;
using FlowerHotel.DAL.Entities;
using FlowerHotel.DAL.Interfaces;
using FlowerHotel.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlowerHotel.BLL.Services
{
    public class OrderService : IOrderService
    {
        IUnitOfWork Database { get; set; }

        public OrderService(IUnitOfWork uow)
        {
            Database = uow;
        }
        public async Task Create(OrderDTO orderDto)
        {
            Order order = new Order();
            order.HotelId = orderDto.HotelId;
            order.ApplicationUserId = orderDto.ApplicationUserId;
            order.PlantId = orderDto.PlantId;
            order.StartTime = orderDto.StartTime;
            order.EndTime = orderDto.EndTime;
            order.IsActive = orderDto.IsActive;
            Database.Orders.Create(order);
            await Database.SaveAsync();
        }
        public async Task Update(OrderDTO orderDto)
        {
            Order order = new Order();
            order.Id = orderDto.Id;
            order.HotelId = orderDto.HotelId;
            order.ApplicationUserId = orderDto.ApplicationUserId;
            order.PlantId = orderDto.PlantId;
            order.StartTime = orderDto.StartTime;
            order.EndTime = orderDto.EndTime;
            order.IsActive = orderDto.IsActive;
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
            var result = new OrderDTO();
            result.Id = order.Id;
            result.HotelId = order.HotelId;
            result.ApplicationUserId = order.ApplicationUserId;
            result.PlantId = order.PlantId;
            result.StartTime = order.StartTime;
            result.EndTime = order.EndTime;
            result.IsActive = order.IsActive;
            return result;
        }

        //TODO Add Get and GetAll methods for one user and hotel
        public void Dispose()
        {
            Database.Dispose();
        }
    }
}
