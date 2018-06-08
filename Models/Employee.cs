using System.ComponentModel.DataAnnotations;

namespace ApiUsuarios.Models
{
    public class Employee
    {
        [Key]
        public int EmployeeID { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Country { get; set; }
    }
}