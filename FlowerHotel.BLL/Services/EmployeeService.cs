using AutoMapper;
using FlowerHotel.BLL.DTO;
using FlowerHotel.BLL.Interfaces;
using FlowerHotel.DAL.Entities;
using FlowerHotel.DAL.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlowerHotel.BLL.Services
{
    public class EmployeeService : IEmployeeService
    {
        private IUnitOfWork Database { get; }

        public EmployeeService(IUnitOfWork uow)
        {
            Database = uow;
        }
        public async Task Create(EmployeeDTO employeeDto)
        {
            var employee = new Employee
            {
                ApplicationUserId = employeeDto.ApplicationUserId,
                HotelId = employeeDto.HotelId
            };
            Database.Employees.Create(employee);
            await Database.SaveAsync();
        }
        public async Task Update(EmployeeDTO employeeDto)
        {
            var employee = new Employee
            {
                Id = employeeDto.Id,
                HotelId = employeeDto.HotelId,
                ApplicationUserId = employeeDto.ApplicationUserId
            };
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
            var result = new EmployeeDTO
            {
                Id = employee.Id,
                HotelId = employee.HotelId,
                ApplicationUserId = employee.ApplicationUserId
            };
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
