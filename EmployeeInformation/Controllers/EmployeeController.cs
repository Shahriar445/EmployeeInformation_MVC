using EmployeeInformation.Interface;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeInformation.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployee _employeRepository;
        public EmployeeController( IEmployee employeeRepository)
        {
            
            _employeRepository = employeeRepository;
        }
        public IActionResult Index()
        {
            var employeeDetails = _employeRepository.DisplayEmployees();
            ViewBag.EmployeeDetails = employeeDetails;
            return View();
        }

    }
}
