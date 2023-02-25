using System.Collections.Generic;
using System.Threading.Tasks;
using Emp.Api.Models;
using Microsoft.EntityFrameworkCore;
using SQLitePCL;

namespace Emp.Api.Repositories
{
    public class EmpRepository : IEmpRepository
    {
        private readonly EmployeeContext _context;

        public EmpRepository(EmployeeContext context)
        {
            _context = context;
        }
        public async Task<Employee> create(Employee employee)
        {
            _context.Employees.Add(employee);
            await _context.SaveChangesAsync();
            return employee;
        }

        public async Task delete(int EmpId)
        {
            var employeeToDelete = await _context.Employees.FindAsync(EmpId);
            _context.Employees.Remove(employeeToDelete);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Employee>> Get()
        {
            return await _context.Employees.ToListAsync();
        }

        public async Task<Employee> Get(int EmpId)
        {
            return await _context.Employees.FindAsync(EmpId);
        }

        public async Task Update(Employee employee)
        {
            _context.Entry(employee).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public Task<Employee> update(Employee employee)
        {
            throw new System.NotImplementedException();
        }
    }
}
