﻿using EmployeeInformation.Interface;
using EmployeeInformation.IRepository;
using EmployeeInformation.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeInformation.Controllers
{
    [Authorize]
    public class EmployeeController : Controller
    {
        private readonly IEmployee _employeRepository;
        public EmployeeController(IEmployee employeeRepository)
        {
            _employeRepository = employeeRepository;
        }
       
        public IActionResult Index()
        {
            try
            {
                var employeeDetails = _employeRepository.DisplayEmployees();
                ViewBag.EmployeeDetails = employeeDetails;
                return View();
            }
            catch (Exception ex)
            {
                // Handle the exception
                return View("Error");
            }
        }
        public IActionResult CreateNewEmployee()
        {
            return View("Create");
        }
        public IActionResult Create(EmployeeModel employee)
        {
            try
            {
                // Your code for creating a new employee
                return View();
            }
            catch (Exception ex)
            {
                // Handle the exception
                return View("Error");
            }
        }

        [HttpPost]
        public IActionResult submit(EmployeeModel employee)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View("Create");
                }

                employee.Id = _employeRepository.GetNextId(); // Assign the next ID
                                                              // _employeRepository.Create(employee);
                _employeRepository.WriteToJson(employee); // Save to Json file 
                TempData["SuccessMessage"] = "Employee created successfully!";
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                // Handle the exception
                return View("Error");
            }
        }

        public IActionResult Delete()
        {
            try
            {
                return View("Delete");
            }
            catch (Exception ex)
            {
                return View("Error");
            }
        }
        public IActionResult Update()
        {
            try
            {
                return View("Update");
            }
            catch (Exception ex)
            {
                return View("Error");
            }
        }

        public IActionResult ConfirmUpdate(EmployeeModel employee)
        {
            try
            {
                var result = _employeRepository.UpdateEmployee(employee);
                TempData["UpdateMessage"] = result;
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                return View("Error");
            }
        }

        [HttpPost]
        public IActionResult ConfirmDelete(int id)
        {
            try
            {
                var result = _employeRepository.DeleteEmployee(id);
                TempData["DeleteMessage"] = result;
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                // Handle the exception
                return View("Error");
            }
        }

      
    }
}
