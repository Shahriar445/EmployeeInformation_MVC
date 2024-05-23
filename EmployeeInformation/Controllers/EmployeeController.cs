using EmployeeInformation.Interface;
using EmployeeInformation.Models;
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

        public IActionResult CreateNewEmployee()
        {
            return View("Create");
        }
        public IActionResult Create(EmployeeModel employee)
        {           
            return View();
        }

        [HttpPost]
        public IActionResult submit(EmployeeModel employee)
        {
           
                _employeRepository.Create(employee);
                _employeRepository.WriteToJson();
                TempData["SuccessMessage"] = "Employee created successfully!";
                return RedirectToAction(nameof(Index));
            
        }
    }
}
