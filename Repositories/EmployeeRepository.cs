using System.Collections.Generic;
using System.Linq;
using ApiUsuarios.Models;

namespace ApiUsuarios.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly Context _context; 
        public EmployeeRepository(Context context)
        {
            _context = context;
        }
        public void Add(Employee employee)
        {
            _context.Employees.Add(employee);
            _context.SaveChanges();
        }

        public Employee Find(int id)
        {
            return _context.Employees.FirstOrDefault(i => i.EmployeeID == id);
        }

        public IEnumerable<Employee> Get()
        {
            return _context.Employees.ToList();
        }

        public void Remove(int id)
        {
            var employee = _context.Employees.First(i => i.EmployeeID == id);
            _context.Employees.Remove(employee);
            _context.SaveChanges(); 
        }

        public void Update(Employee employee)
        {
            _context.Employees.Update(employee);
            _context.SaveChanges();
        }
    }
}