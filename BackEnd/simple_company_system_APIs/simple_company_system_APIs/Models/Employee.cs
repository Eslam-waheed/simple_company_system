using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace simple_company_system_APIs.Models
{
    public class Employee
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "Name can only contain letters and spaces")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Address is required")]
        [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "Address can only contain letters and spaces")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Salary is required")]
        [Range(1, 100000, ErrorMessage = "Salary must be greater than 0")]
        public int Salary { get; set; }

        [ForeignKey("Department")]
        [Required(ErrorMessage = "Department is required")]
        public int Dept_id { get; set; }

        public virtual Department? Department { get; set; }

        public ICollection<EmployeeProject> EmployeeProjects { get; set; }
    }
}
