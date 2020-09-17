using EmployeeService.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeService.Data
{
    public class EmployeeContext : DbContext
    {
        public EmployeeContext([NotNullAttribute] DbContextOptions options) : base(options)
        {
        }
        protected EmployeeContext()
        {
        }
        public virtual DbSet<Employee> Employees { get; set; }
    }
}
