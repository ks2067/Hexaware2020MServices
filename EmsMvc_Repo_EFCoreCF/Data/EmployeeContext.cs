using EmsMvc;
using EmsMvc.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;

namespace EmsMvc_Repo_EFCoreCF.Data
{
    public class EmployeeContext : DbContext
    {
        public EmployeeContext([NotNullAttribute] DbContextOptions options) : base(options)
        {
        }

        protected EmployeeContext()
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //fluent API
            //modelBuilder.Entity<Employee>().HasData(
            //    new Employee
            //    {
            //        Id = 1,
            //        Name = "Param",
            //        DateOfJoining = new DateTime(2020, 9, 9),
            //        Phone = 9988990098,
            //        Email = "param@hexaware.com",
            //        Gender = Gender.Male
            //    },
            //    new Employee
            //    {
            //        Id = 2,
            //        Name = "Shona",
            //        DateOfJoining = new DateTime(2020, 9, 9),
            //        Phone = 9988990098,
            //        Email = "shona@hexaware.com",
            //        Gender = Gender.Female
            //    });

            // non SQL server database
            modelBuilder.UseIdentityColumns();
            base.OnModelCreating(modelBuilder);
        }
        public virtual DbSet<Employee> Employees { get; set; }
    }
}
