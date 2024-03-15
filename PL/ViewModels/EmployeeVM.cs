using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using DAL.Entity;

namespace PL.ViewModels
{
    public class EmployeeVM
    {
        public int Id { get; set; }
        [MaxLength(30), MinLength(5)]
        [Required(ErrorMessage = "Name is Required")]
        public string Name { get; set; }
        [DataType(DataType.Currency)]
        public decimal Salary { get; set; }
        [Range(20, 60)]
        public int Age { get; set; }
        public bool IsActive { get; set; }
        public string Address { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        [Phone]
        public string Phone { get; set; }
        public DateTime HireDate { get; set; }
        //-----------------------------------------
        public Department? Department { get; set; }
        public int? DepartmentId { get; set; }
    }
}
