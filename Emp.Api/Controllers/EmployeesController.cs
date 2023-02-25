using System.Collections;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;
using Emp.Api.Models;
using Emp.Api.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Emp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmpRepository _empRepository;

        public EmployeesController(IEmpRepository EmpRepository)
        {
            _empRepository = EmpRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<Employee>> GetEmployees()
        {
            return await _empRepository.Get();
        }

        [HttpGet("EmpId")]
        public async Task<ActionResult<Employee>> GetEmployees(int EmpId)
        {
            return await _empRepository.Get(EmpId);
        }
        [HttpPost]
        public async Task<ActionResult<Employee>> PostEmployees([FromBody] Employee employee)
            {
            var newEmployee = await _empRepository.create(employee);
            return CreatedAtAction(nameof(GetEmployees),
                new { EmpId = newEmployee.EmpId }, newEmployee);
            }
        [HttpPut]
        public async Task<ActionResult> PutEmployees(int EmpId, [FromBody]Employee employee)
        {
            if(EmpId != employee.EmpId)
            {
                return BadRequest();
            }
            await _empRepository.update(employee);
            return NoContent();
        }

        [HttpDelete]
        public async Task<ActionResult> Delete (int EmpId)
        {
            var employeesToDelete = await _empRepository.Get(EmpId);
            if(employeesToDelete != null) 
                return NotFound();
            await _empRepository.delete(employeesToDelete.EmpId);
            return NoContent();
        }

    }
}
