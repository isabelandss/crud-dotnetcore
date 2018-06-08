using System;
using System.Collections.Generic;
using ApiUsuarios.Models;
using ApiUsuarios.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace ApiUsuarios.Controllers
{
    [Route("api/[controller]")]
    public class EmployeeController : Controller
    {
        private readonly IEmployeeRepository _employeeRepository;
        public EmployeeController(IEmployeeRepository employeeRepo)
        {
            _employeeRepository = employeeRepo;
        }

        [HttpGet]
        public IEnumerable<Employee> get() {
            return _employeeRepository.Get();
        }

        [HttpGet("{id}", Name = "GetUsuario")]
        public IActionResult getById(int id) {
            var employee = _employeeRepository.Find(id);

            Predicate<Employee> isNull = x => x == null;

            if(isNull(employee)) {
                return NotFound();
            }
            return Ok(employee);
        }

        [HttpPost]
        public IActionResult post([FromBody] Employee employee) {
            if(employee == null) {
                return BadRequest();
            }
            _employeeRepository.Add(employee);
            
            return CreatedAtRoute("GetUsuario", new { id = employee.EmployeeID }, employee);
        }

        [HttpPut("{id}")]
        public IActionResult put(int id, [FromBody] Employee employee) {
            if(employee == null || employee.EmployeeID != id) {
                return BadRequest();
            }

            var _employee = _employeeRepository.Find(id);

            if(_employee == null) {
                return NotFound();
            }
            
            _employee.Country = employee.Country;
            _employee.FirstName = employee.FirstName;

            _employeeRepository.Update(_employee);
            return new NoContentResult(); 
        }

        [HttpDelete("{id}")]
        public IActionResult delete(int id) {
            var employee = _employeeRepository.Find(id);

            if(employee == null) {
                return NotFound();
            }

            _employeeRepository.Remove(id);
            return new NoContentResult();
        }
    }
}