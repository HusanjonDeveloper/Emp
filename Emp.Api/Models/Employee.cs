using System.ComponentModel.DataAnnotations;

namespace Emp.Api.Models
{
    public class Employee
    {
        [Key]
        public int  EmpId { get; set; }
        public string  Name { get; set; }
        public string  Debt { get; set; }
        public string Adderss { get; set; }

    }
}
