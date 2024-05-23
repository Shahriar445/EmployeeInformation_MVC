namespace EmployeeInformation.Interface
{
    public interface IEmployee
    {
       
       
        public string CreateEmployee() ;
        public string DeleteEmployee();
        public string UpdateEmployee();
       
        public void ReadFromJson();// done
        public void ReadToJson();
        public string DisplayEmployees(); // done
    }
}
