using System.Collections.Generic;
using ApiUsuarios.Models;

namespace ApiUsuarios.Repositories
{
    public interface IEmployeeRepository
    {
        void Add(Employee employee);
        IEnumerable<Employee> Get();
        Employee Find(int id);
        void Remove(int id);
        void Update(Employee employee);
    }
}