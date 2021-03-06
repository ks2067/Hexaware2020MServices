﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EmsMvc.Models
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        [DataType(DataType.Date)]
        //to be past
        public DateTime DateOfJoining { get; set; }
        [EmailAddress]
        [Required]
        public string Email { get; set; }
        [Required]
        [Range(1000000000, 9999999999)]
        public long Phone { get; set; }
        [Required]
        public Gender Gender { get; set; } 
    }
}
