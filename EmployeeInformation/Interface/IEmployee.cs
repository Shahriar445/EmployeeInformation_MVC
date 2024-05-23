using EmployeeInformation.Models;

namespace EmployeeInformation.Interface
{
    public interface IEmployee
    {


        public string Create(EmployeeModel employee);
        public string DeleteEmployee();
        public string UpdateEmployee();

        public void ReadFromJson();// done
        public void WriteToJson();
        public string DisplayEmployees(); // done
    }
}
