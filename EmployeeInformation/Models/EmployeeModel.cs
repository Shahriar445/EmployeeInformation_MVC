using Microsoft.VisualBasic;

namespace EmployeeInformation.Models
{
    public class EmployeeModel
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Code { get; set; }
        public DateAndTime? Dob { get; set; }
        public DateAndTime? DateofJoing { get; set; }
        public string? BloodGroup { get; set; }
        public int DepartmentId { get; set; }
        public bool IsActive { get; set; }
    }
}
