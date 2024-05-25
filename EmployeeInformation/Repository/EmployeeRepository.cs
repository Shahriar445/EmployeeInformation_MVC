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
            try
            {
                ReadFromJson(); // Ensure the current state of Employees is loaded
                var employeeToDelete = _employees.FirstOrDefault(x => x.Id == id);
                if (employeeToDelete != null)
                {
                    _employees.Remove(employeeToDelete);
                    WriteToJson_for_Update();  // update to Json file 
                    return "Employee deleted successfully.";
                }
                else
                {
                    return "Employee not found.";
                }

            }catch(Exception ex)
            {
                return "Not Valid Excepetions";
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
                // $"Error occurred while reading from JSON file: {e.Message}";
              
            }
            
            
        }
        public EmployeeModel GetEmployeeById(int id)
        {
            ReadFromJson();
            return _employees.FirstOrDefault(x => x.Id == id);
        }
        public string UpdateEmployee(EmployeeModel _updatedEmployee)
        {
            ReadFromJson();
            var employeeToUpdate = _employees.FirstOrDefault(x => x.Id == _updatedEmployee.Id);
            if (employeeToUpdate != null)
            {
                // Update the employee details
                employeeToUpdate.Name = _updatedEmployee.Name;
                employeeToUpdate.Code = _updatedEmployee.Code;
                employeeToUpdate.DepartmentId = _updatedEmployee.DepartmentId;
                employeeToUpdate.BloodGroup = _updatedEmployee.BloodGroup;
                employeeToUpdate.DateofJoing = _updatedEmployee.DateofJoing;
                employeeToUpdate.Dob = _updatedEmployee.Dob;
                employeeToUpdate.IsActive = _updatedEmployee.IsActive;

                WriteToJson_for_Update(); // Update the JSON file
                return "Employee updated successfully.";
            }
            else
            {
                return "Employee not found.";
            }   

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
        public void WriteToJson_for_Update()
        {
            try
            {
                // Serialize the current list of employees to JSON
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
