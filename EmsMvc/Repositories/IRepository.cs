using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmsMvc.Repositories
{
    public interface IRepository<T>
    {
        bool Add(T entity);
        bool Update(T entity);
        bool Delete(object key);
        T Get(object key);
        IEnumerable<T> Get();
    }
}

//IEmpRepo<Employee> //: Irepositoy<Employee>
//    {
//        Find()
//    GetEmpByDept(int deptid);
//    }

//EmpRepo: IEmpRepo<Employee>, IRepo
//    {
            
//    }
//    DeptRepo:
//    {

//    }
//    ProjectRepo
