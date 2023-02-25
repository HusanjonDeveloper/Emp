using Microsoft.EntityFrameworkCore;

namespace Emp.Api.Models
{
    public class EmployeeContext: DbContext
    {
        public EmployeeContext(DbContextOptions<EmployeeContext> options) :
            base(options) => Database.EnsureCreated();
        public DbSet<Employee> Employees { get; set;} 
    }

}
