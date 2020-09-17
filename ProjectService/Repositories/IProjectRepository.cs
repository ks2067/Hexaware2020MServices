using ProjectService.Models;
using ProjectService.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectService.Repositories
{
    public interface IProjectRepository : IRepository<Project>
    {
            //IEnumerable<Employee> GetByGender(Gender gender);
    }
}
