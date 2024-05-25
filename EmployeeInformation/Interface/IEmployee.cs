using EmployeeInformation.Models;

namespace EmployeeInformation.Interface
{
    public interface IEmployee
    {


        public string Create(EmployeeModel employee);
        public string DeleteEmployee(int id); // Working on 
        public string UpdateEmployee(); 

        public void ReadFromJson();// done
        public void WriteToJson(EmployeeModel employee); //done
        public string DisplayEmployees(); // done
        public int GetNextId(); //done . This method work on auto increment E_Id
        public void WriteToJson_for_Update();


    }
}
