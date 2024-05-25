using EmployeeInformation.Interface;
using EmployeeInformation.IRepository;
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
            if (!ModelState.IsValid)
            {
                return View("Create");
            }

            employee.Id =_employeRepository.GetNextId(); // Assign the next ID
             // _employeRepository.Create(employee);
            _employeRepository.WriteToJson(employee); // Save to Json file 
                TempData["SuccessMessage"] = "Employee created successfully!";
                return RedirectToAction(nameof(Index));
            
        }

       
        public IActionResult Delete(int id)
        {
            var employee = _employeRepository.DeleteEmployee(id);
            if (employee == null)
            {
                return NotFound(); // Or handle the case when the employee is not found
            }

            return View("Delete");
        }
        [HttpPost]
        public IActionResult ConfirmDelete(int id)
        {
            var result = _employeRepository.DeleteEmployee(id);
            TempData["DeleteMessage"] = result;
            return RedirectToAction(nameof(Index));
        }

    }
}
