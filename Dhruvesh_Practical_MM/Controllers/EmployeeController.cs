﻿using Dhruvesh_Practical_MM.Models;
using Dhruvesh_Practical_MM.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Dhruvesh_Practical_MM.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeRepo _employeeRepo;

        private readonly IStateCityRepo _stateCityRepo;

        public EmployeeController(IEmployeeRepo employeeRepo , IStateCityRepo stateCityRepo)
        {
             _employeeRepo = employeeRepo;
            _stateCityRepo = stateCityRepo;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult AddEmployee()
        {
            var getstate = _stateCityRepo.GetAllState();
            ViewBag.State = new SelectList(getstate, "c_stateid", "c_statename");
            return View();
        }
        [HttpPost]
        public IActionResult AddEmployee(EmployeeModel employeeModel)
        {
            _employeeRepo.AddEmployee(employeeModel);
            return RedirectToAction("GetAllEmployee", "Employee");

        }

        public IActionResult GetAllEmployee()
        {
            var getemployee = _employeeRepo.GetAllEmployee();
            return View(getemployee);
        }

        public IActionResult GetEmployeeById(int id)
        {
            var get = _employeeRepo.GetEmployeeById(id);
            return Json(get);
        }

        public IActionResult DeleteEmployee(int id)
        {
            _employeeRepo.DeleteEmployee(id);
            return RedirectToAction("GetAllEmployee" , "Employee");
        }

        [HttpGet]
        public IActionResult UpdateEmployee(int id)
        {
            var getstate = _stateCityRepo.GetAllState();
            ViewBag.State = new SelectList(getstate, "c_stateid", "c_statename");
            var GetById = _employeeRepo.GetEmployeeById(id);
            return View(GetById);
        }

        [HttpPost]
        public IActionResult UpdateEmployee(EmployeeModel employeeModel)
        {
            _employeeRepo.UpdateEmployee(employeeModel);
            return RedirectToAction("GetAllEmployee", "Employee");

        }
    }
}