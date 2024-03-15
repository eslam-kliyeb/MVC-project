﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entity
{
    public class Department
    {
        public int Id { get; set; }
        [MaxLength(30)]
        public string Name { get; set; }
        [MaxLength(10), MinLength(1)]
        public string Code { get; set; }
        public DateTime CreateAt { get; set; }
        //----------------------------------------------------
        public ICollection<Employee>? Employees { get; set; }
    }
}
