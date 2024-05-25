using EmployeeInformation.Models;

namespace EmployeeInformation.Interface
{
    public interface IEmployee
    {


        public string Create(EmployeeModel employee); //done
        public string DeleteEmployee(int id); // done
        public void ReadFromJson();// done
        public void WriteToJson(EmployeeModel employee); //done
        public string DisplayEmployees(); // done
        public int GetNextId(); //done . This method work on auto increment E_Id
        public void WriteToJson_for_Update(); //done

        public string UpdateEmployee(EmployeeModel employee); //working on it
        public EmployeeModel GetEmployeeById(int id);

        public string Login();


    }
}
