
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjectService.Data;
using ProjectService.Models;

namespace ProjectService.Repositories
{
    public class ProjectRepository : IProjectRepository
    {
        private ProjectContext context;
        public ProjectRepository(ProjectContext context)
        {
            this.context = context;
        }
        public bool Add(Project entity)
        {
            try
            {
                context.Projects.Add(entity);
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
                context.Projects.Remove(emp);
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
        public Project Get(object key)
        {
            context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
            return context.Projects.Find(key);
        }
        public IEnumerable<Project> Get()
        {
            return context.Projects;
        }
        public bool Update(Project entity)
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

