using Microsoft.VisualBasic;
using System.ComponentModel.DataAnnotations;

namespace EmployeeInformation.Models
{
    public class EmployeeModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required.")]
        [StringLength(100, ErrorMessage = "Name cannot exceed 100 characters.")]
        public string ?Name { get; set; }

       
        public string? Code { get; set; }

        [Required(ErrorMessage = "Department ID is required.")]
        public int DepartmentId { get; set; }

        [Required(ErrorMessage = "Blood Group is required.")]
        public string ?BloodGroup { get; set; }

        [Required(ErrorMessage = "Date of Joining is required.")]
        [DataType(DataType.Date)]
        public string? DateofJoing { get; set; }

        [Required(ErrorMessage = "Date of Birth is required.")]
        [DataType(DataType.Date)]
        public string? Dob { get; set; }

        [Required(ErrorMessage = "Active status is required.")]
        public bool IsActive { get; set; }
    }
}
