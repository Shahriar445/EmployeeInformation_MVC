using EmployeeInformation.Interface;
using EmployeeInformation.Models;
using System.Text;
using System.Text.Json;

namespace EmployeeInformation.IRepository
{
    public class EmployeeRepository : IEmployee
    {

       private readonly string Path = @"C:\Users\Hameem\Desktop\Intern - Shahriar Haque (Shipon)\Core MVC\EmployeeInformation\EmployeeInformation\employee.json";
      private  List<EmployeeModel> _employees = new List<EmployeeModel>();


        //Create Employee 
        public string Create(EmployeeModel employee)
        {
            _employees.Add(employee);
            WriteToJson( employee);
            return Path;
        }

        public string DeleteEmployee(int id)
        {
            ReadFromJson(); // Ensure the current state of Employees is loaded
            var employeeToDelet= _employees.FirstOrDefault(x => x.Id == id);
            if (employeeToDelet != null)
            {
                _employees.Remove(employeeToDelet);
                WriteToJson(employeeToDelet);  // update to Json file 
                return "Employee deleted successfully.";
            }
            else
            {
                return "Employee not found.";
            }
        }

        public void ReadFromJson() // Read All Employee List From Employee.Json 
        {
            try
            {
                var op = File.ReadAllText(Path);

                _employees = JsonSerializer.Deserialize<List<EmployeeModel>>(op);
            }
            catch(Exception e)
            {
                Console.WriteLine($"Error occurred while reading from JSON file: {e.Message}");
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
            foreach (var employeePrint in _employees)
            {

                employeeDisplay.AppendLine($"Employee Id: {employeePrint.Id}");
                employeeDisplay.AppendLine($"Employee Name: {employeePrint.Name}");
                employeeDisplay.AppendLine($"Employee Code: {employeePrint.Code}");
                employeeDisplay.AppendLine($"Employee Department: {employeePrint.DepartmentId}");
                employeeDisplay.AppendLine($"Employee Blood Group: {employeePrint.BloodGroup}");
                employeeDisplay.AppendLine($"Employee Date of Joining: {employeePrint.DateofJoing}");
                employeeDisplay.AppendLine($"Employee Date of Birth: {employeePrint.Dob}");
                employeeDisplay.AppendLine($"Employee Active/InActive: {employeePrint.IsActive}");
                employeeDisplay.AppendLine();
            }
            return employeeDisplay.ToString();
        }

        // here update all the customr details to json files 
        public void WriteToJson(EmployeeModel newEmployee)
        {
            try
            {
                
                // Check if the file exists and read the existing employees
                if (File.Exists(Path))
                {
                    var existingJson = File.ReadAllText(Path);
                    if (!string.IsNullOrEmpty(existingJson))
                    {
                        _employees = JsonSerializer.Deserialize<List<EmployeeModel>>(existingJson);
                    }
                }

                // Add the new employee to the list
                _employees.Add(newEmployee);

                // Serialize the updated list back to JSON
                var options = new JsonSerializerOptions
                {
                    WriteIndented = true
                };
                var json = JsonSerializer.Serialize(_employees, options);

                // Write the updated JSON to the file
                File.WriteAllText(Path, json);
            }
            catch (Exception ex)
            {
                // Handle the exception here, e.g., log the error
                Console.WriteLine($"Error occurred while writing to JSON file: {ex.Message}");
            }
        }
        public int GetNextId() // auto E_id Increment 
        {
            ReadFromJson(); // Read the existing employees
            if (_employees.Count == 0)
            {
                return 1;
            }
            return _employees.Max(e => e.Id) + 1;
        }




    }


}
