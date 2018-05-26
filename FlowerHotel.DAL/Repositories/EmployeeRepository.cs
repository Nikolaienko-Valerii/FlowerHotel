using FlowerHotel.DAL.Interfaces;
using FlowerHotel.DAL.Entities;
using System;
using System.Collections.Generic;
using FlowerHotel.DAL.EF;
using System.Data.Entity;
using System.Linq;

namespace FlowerHotel.DAL.Repositories
{
    public class EmployeeRepository : IRepository<Employee>
    {
        private ApplicationContext _db;

        public EmployeeRepository(ApplicationContext context)
        {
            _db = context;
        }

        public IEnumerable<Employee> GetAll()
        {
            return _db.Employees.Include(e => e.Hotel);
        }

        public Employee Get(int id)
        {
            return _db.Employees.Find(id);
        }

        public void Create(Employee employee)
        {
            _db.Employees.Add(employee);
        }

        public void Update(Employee employee)
        {
            _db.Entry(employee).State = EntityState.Modified;
        }

        public IEnumerable<Employee> Find(Func<Employee, Boolean> predicate)
        {
            return _db.Employees.Where(predicate).ToList();
        }

        public void Delete(int id)
        {
            Employee employee = _db.Employees.Find(id);
            if (employee != null)
                _db.Employees.Remove(employee);
        }
    }
}
