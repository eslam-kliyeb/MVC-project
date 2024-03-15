using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entity
{
    public class Employee
    {
        public int Id { get; set; }
        [MaxLength(30)]
        public string Name { get; set; }
        [Column(TypeName="Money")]
        public decimal Salary { get; set; }
        public int Age { get; set; }
        public bool IsActive { get; set; }
        public string Address { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        [Phone]
        public string Phone { get; set; }
        public DateTime HireDate { get; set; }
        //-----------------------------------------
        public  Department? Department { get; set; }
        public int? DepartmentId {  get; set; }
    }
}
