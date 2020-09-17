using DepartmentService.Models;
using DepartmentService.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DepartmentService.Repositories
{
    public interface IDepartmentRepository : IRepository<Department>
    {
            //IEnumerable<Employee> GetByGender(Gender gender);
    }
}
