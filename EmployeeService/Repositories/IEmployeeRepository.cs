using EmployeeService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeService.Repositories
{
    public interface IEmployeeRepository : IRepository<Employee>
    {
            IEnumerable<Employee> GetByGender(Gender gender);
    }
}
