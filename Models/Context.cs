using Microsoft.EntityFrameworkCore;

namespace ApiUsuarios.Models
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) 
            : base(options) { }

        public DbSet<Employee> Employees { get; set; }
    }
}