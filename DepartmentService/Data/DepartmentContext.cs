using DepartmentService.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;

namespace DepartmentService.Data
{
    public class DepartmentContext : DbContext
    {
        public DepartmentContext([NotNullAttribute] DbContextOptions options) : base(options)
        {
        }
        protected DepartmentContext()
        {
        }
        public virtual DbSet<Department> Departments { get; set; }
    }
}
