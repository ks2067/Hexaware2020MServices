
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DepartmentService.Data;
using DepartmentService.Models;

namespace DepartmentService.Repositories
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private DepartmentContext context;
        public DepartmentRepository(DepartmentContext context)
        {
            this.context = context;
        }
        public bool Add(Department entity)
        {
            try
            {
                context.Departments.Add(entity);
                int result = context.SaveChanges();
                if (result > 0)
                {
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                throw ex; //throwing wrapper, no stack trace
                //throw;      //rethrow
            }
        }
        public bool Delete(object key)
        {
            var emp = Get(key);
            if (emp == null)
            {
                return false;
            }
            try
            {
                context.Departments.Remove(emp);
                var result = context.SaveChanges();
                if (result > 0)
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
        public Department Get(object key)
        {
            context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
            return context.Departments.Find(key);
        }
        public IEnumerable<Department> Get()
        {
            return context.Departments;
        }
        public bool Update(Department entity)
        {
            try
            {
                context.Entry(entity).State = EntityState.Modified;
                int result = context.SaveChanges();
                if (result > 0)
                {
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                //log
                throw ex;
            }
        }
    }

}

