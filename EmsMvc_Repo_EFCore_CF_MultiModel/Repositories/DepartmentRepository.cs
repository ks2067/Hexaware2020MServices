using EmsMvc_Repo_EFCore_CF_MultiModel.Data;
using EmsMvc_Repo_EFCore_CF_MultiModel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmsMvc_Repo_EFCore_CF_MultiModel.Repositories
{
    public class DepartmentRepository : IRepository<Department>
    {
        private EmsContext context;
        public DepartmentRepository(EmsContext context)
        {
            this.context = context;
        }
        public bool Add(Department entity)
        {
            try
            {
                context.Departments.Add(entity);
                var result = context.SaveChanges();
                if(result > 0)
                {
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Delete(object key)
        {
            throw new NotImplementedException();
        }

        public Department Get(object key)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Department> Get()
        {
            return context.Departments;
        }

        public bool Update(Department entity)
        {
            throw new NotImplementedException();
        }
    }
}
