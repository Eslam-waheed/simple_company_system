using System.ComponentModel.DataAnnotations;

namespace simple_company_system_APIs.DTO.Department
{
    public class CreateAndEditDepartment
    {
        [Required(ErrorMessage = "Name is required")]
        [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "Name can only contain letters and spaces")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Description is required")]
        [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "Description can only contain letters and spaces")]
        public string Description { get; set; }
    }
}
