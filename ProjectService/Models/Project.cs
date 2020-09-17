using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectService.Models
{
    public class Project
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Client { get; set; }
        [Required]
        public int ProjectManager { get; set; } 
        //public virtual ICollection<Employee> Employees { get; set; }
        //public virtual Department Department { get; set; }
    }
}
