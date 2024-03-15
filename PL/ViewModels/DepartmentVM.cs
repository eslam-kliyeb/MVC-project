using DAL.Migrations;
using System.ComponentModel.DataAnnotations;

namespace PL.ViewModels
{
    public class DepartmentVM
    {
        public int Id { get; set; }
        [MinLength(5)]
        [Required(ErrorMessage = "Name is Required")]
        public string Name { get; set; }
        [MinLength(1)]
        [Required(ErrorMessage = "Name is Required")]
        public string Code { get; set; }
        public DateTime CreateAt { get; set; }
        //----------------------------------------------------
        public ICollection<Employee>? Employees { get; set; }
    }
}
