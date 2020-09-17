using Microsoft.EntityFrameworkCore;
using ProjectService.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectService.Data
{
    public class ProjectContext: DbContext
    {
        public ProjectContext([NotNullAttribute] DbContextOptions options) : base(options)
        {
        }
        protected ProjectContext()
        {
        }
        public virtual DbSet<Project> Projects { get; set; }
    }
}
