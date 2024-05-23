using EmployeeInformation.Interface;
using EmployeeInformation.Models;
using System.Text;
using System.Text.Json;

namespace EmployeeInformation.IRepository
{
    public class EmployeeRepository : IEmployee
    {

        string Path = @"C:\\Users\\Hameem\\Desktop\\Intern - Shahriar Haque (Shipon)\\Core MVC\\EmployeeInformation\\EmployeeInformation\\employee.json";
        List<EmployeeModel> employees = new List<EmployeeModel>();

        public string CreateEmployee()
        {
            throw new NotImplementedException();
        }

        public string DeleteEmployee()
        {
            throw new NotImplementedException();
        }

       

        public void ReadFromJson()
        {
            var op = File.ReadAllText(Path);

            employees = JsonSerializer.Deserialize<List<EmployeeModel>>(op);
            
        }

      
        public string UpdateEmployee()
        {
            throw new NotImplementedException();
        }
        public string DisplayEmployees()
        {
            ReadFromJson();
            var employeeDisplay = new StringBuilder();
            foreach (var employee in employees)
            {

                employeeDisplay.AppendLine($"Employee Id: {employee.Id}");
                employeeDisplay.AppendLine($"Employee Name: {employee.Name}");
                employeeDisplay.AppendLine($"Employee Code: {employee.Code}");
                employeeDisplay.AppendLine($"Employee Department: {employee.DepartmentId}");
                employeeDisplay.AppendLine($"Employee Blood Group: {employee.BloodGroup}");
                employeeDisplay.AppendLine($"Employee Date of Joining: {employee.DateofJoing}");
                employeeDisplay.AppendLine($"Employee Date of Birth: {employee.Dob}");
                employeeDisplay.AppendLine($"Employee Active/InActive: {employee.IsActive}");
                employeeDisplay.AppendLine();
            }
            return employeeDisplay.ToString();
        }

        void IEmployee.ReadToJson()
        {
            throw new NotImplementedException();
        }
    }


}
