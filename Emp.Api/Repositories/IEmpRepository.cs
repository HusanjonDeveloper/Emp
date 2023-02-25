using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Emp.Api.Models;

namespace Emp.Api.Repositories
{
    public interface IEmpRepository
    {
        Task<IEnumerable<Employee>> Get();
        Task<Employee> Get(int EmpId);
        Task<Employee> create(Employee employee);
        Task<Employee> update(Employee employee);
        Task delete(int EmpId);

       
    }
}
