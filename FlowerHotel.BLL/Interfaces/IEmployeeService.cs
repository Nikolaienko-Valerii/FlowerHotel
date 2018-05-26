using FlowerHotel.BLL.DTO;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FlowerHotel.BLL.Interfaces
{
    public interface IEmployeeService : IDisposable
    {
        Task Create(EmployeeDTO employeeDto);
        Task Update(EmployeeDTO employeeDto);
        Task Delete(int employeeId);
        IEnumerable<EmployeeDTO> GetAll();
        EmployeeDTO Get(int employeeId);
        int GetEmployeeHotelId(string userId);
        IEnumerable<EmployeeDTO> GetHotelEmployees(int hotelId);
    }
}
