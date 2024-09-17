using System.ComponentModel.DataAnnotations;

namespace simple_company_system_APIs.DTO.Employee
{
    public class CreateAndEditEmployee
    {
        [Required(ErrorMessage = "Name is required")]
        [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "Name can only contain letters and spaces")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Address is required")]
        [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "Address can only contain letters and spaces")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Salary is required")]
        [Range(1, 100000, ErrorMessage = "Salary must be greater than 0")]
        public int Salary { get; set; }

        [Required(ErrorMessage = "Department is required")]
        public int Dept_id { get; set; }
    }
}
