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
    public class EmployeeService : IEmployeeService
    {
        IUnitOfWork Database { get; set; }

        public EmployeeService(IUnitOfWork uow)
        {
            Database = uow;
        }
        public async Task Create(EmployeeDTO employeeDto)
        {
            Employee employee = new Employee();
            employee.ApplicationUserId = employeeDto.ApplicationUserId;
            employee.HotelId = employeeDto.HotelId;
            Database.Employees.Create(employee);
            await Database.SaveAsync();
        }
        public async Task Update(EmployeeDTO employeeDto)
        {
            Employee employee = new Employee();
            employee.Id = employeeDto.Id;
            employee.HotelId = employeeDto.HotelId;
            employee.ApplicationUserId = employeeDto.ApplicationUserId;
            Database.Employees.Update(employee);
            await Database.SaveAsync();
        }
        public async Task Delete(int employeeId)
        {
            Database.Employees.Delete(employeeId);
            await Database.SaveAsync();
        }
        public IEnumerable<EmployeeDTO> GetAll()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Employee, EmployeeDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<Employee>, List<EmployeeDTO>>(Database.Employees.GetAll());
        }
        public EmployeeDTO Get(int employeeId)
        {
            var employee = Database.Employees.Get(employeeId);
            var result = new EmployeeDTO();
            result.Id = employee.Id;
            result.HotelId = employee.HotelId;
            result.ApplicationUserId = employee.ApplicationUserId;
            return result;
        }

        public IEnumerable<EmployeeDTO> GetHotelEmployees(int hotelId)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Employee, EmployeeDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<Employee>, List<EmployeeDTO>>(Database.Employees.Find(p => p.HotelId == hotelId));
        }

        public int GetEmployeeHotelId(string userId)
        {
            var employees = Database.Employees.Find(e => e.ApplicationUserId == userId);
            var employee = employees.First();
            return employee.HotelId;
        }

        public void Dispose()
        {
            Database.Dispose();
        }
    }
}
