using FlowerHotel.DAL.Interfaces;
using FlowerHotel.DAL.Entities;
using System;
using System.Collections.Generic;
using FlowerHotel.DAL.EF;
using System.Text;
using System.Data.Entity;
using System.Linq;

namespace FlowerHotel.DAL.Repositories
{
    public class EmployeeRepository : IRepository<Employee>
    {
        private ApplicationContext db;

        public EmployeeRepository(ApplicationContext context)
        {
            this.db = context;
        }

        public IEnumerable<Employee> GetAll()
        {
            return db.Employees.Include(e => e.Hotel);
        }

        public Employee Get(int id)
        {
            return db.Employees.Find(id);
        }

        public void Create(Employee employee)
        {
            db.Employees.Add(employee);
        }

        public void Update(Employee employee)
        {
            db.Entry(employee).State = EntityState.Modified;
        }

        public IEnumerable<Employee> Find(Func<Employee, Boolean> predicate)
        {
            return db.Employees.Where(predicate).ToList();
        }

        public void Delete(int id)
        {
            Employee employee = db.Employees.Find(id);
            if (employee != null)
                db.Employees.Remove(employee);
        }
    }
}
