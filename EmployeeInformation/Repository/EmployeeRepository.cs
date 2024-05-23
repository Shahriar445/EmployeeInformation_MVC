using EmployeeInformation.Interface;
using EmployeeInformation.Models;
using System.Text;
using System.Text.Json;

namespace EmployeeInformation.IRepository
{
    public class EmployeeRepository : IEmployee
    {

       private readonly string Path = @"C:\\Users\\Hameem\\Desktop\\Intern - Shahriar Haque (Shipon)\\Core MVC\\EmployeeInformation\\EmployeeInformation\\employee.json";
      private  List<EmployeeModel> _employees = new List<EmployeeModel>();


        //Create Employee 
        public string Create(EmployeeModel employee)
        {
            _employees.Add(employee);
            WriteToJson();
            return Path;
        }

        public string DeleteEmployee()
        {
            throw new NotImplementedException();
        }

       

        public void ReadFromJson()
        {
            try
            {
                var op = File.ReadAllText(Path);

                _employees = JsonSerializer.Deserialize<List<EmployeeModel>>(op);
            }
            catch(Exception e)
            {
                
            }
            
            
        }

      
        public string UpdateEmployee()
        {
            throw new NotImplementedException();
        }
        public string DisplayEmployees()
        {
            ReadFromJson();
            var employeeDisplay = new StringBuilder();
            foreach (var employee in _employees)
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

        // here update all the customr details to json files 
        public void WriteToJson()
        {
            try
            {
                var options = new JsonSerializerOptions
                {
                    WriteIndented = true
                };
                var json = JsonSerializer.Serialize(_employees, options);
                File.WriteAllText(Path, json);
            }
            catch (Exception ex)
            {
                // Handle the exception here, e.g., log the error
                Console.WriteLine($"Error occurred while writing to JSON file: {ex.Message}");
            }
        }



    }


}
