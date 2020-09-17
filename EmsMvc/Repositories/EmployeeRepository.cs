using EmsMvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmsMvc.Repositories
{
    public class EmployeeRepository : IRepository<Employee>
    {
        List<Employee> employeeList = new List<Employee>
        {
            new Employee
            {
                Id = 1,
                Name = "Param",
                DateOfJoining = new DateTime(2020, 9, 9),
                Phone = 9988990098,
                Email = "param@hexaware.com",
                Gender = Gender.Male
            },
            new Employee
            {
                Id = 2,
                Name = "Shona",
                DateOfJoining = new DateTime(2020, 9, 9),
                Phone = 9988990098,
                Email = "shona@hexaware.com",
                Gender = Gender.Female
            }
        };

        public bool Add(Employee entity)
        {
            employeeList.Add(entity);
            return true;
        }

        public bool Delete(object key)
        {
            //employeeList.Remove()
            return true;
        }

        public Employee Get(object key)
        {
            return employeeList.Find(e => e.Id == Convert.ToInt32(key));
        }

        public IEnumerable<Employee> Get()
        {
            return employeeList;

            //employeeList.Select()
        }

        public bool Update(Employee entity)
        {
            //find emp
            // if found, update
            throw new NotImplementedException();
        }
    }
}
