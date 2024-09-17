using System.ComponentModel.DataAnnotations;

namespace simple_company_system_APIs.Models
{
    public class EmployeeProject
    {
        [Required(ErrorMessage = "EmployeeId is required")]
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }

        [Required(ErrorMessage = "ProjectId is required")]
        public int ProjectId { get; set; }
        public Project Project { get; set; }

        public int NumberOfHoursInthisProject { get; set; }
    }
}
