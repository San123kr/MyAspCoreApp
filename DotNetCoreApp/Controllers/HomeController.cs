using DotNetCoreApp.Models;
using DotNetCoreApp.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetCoreApp.Controllers
{
    public class HomeController:Controller
    {
        private readonly IEmployeeRepository _employeeRepository;
        public HomeController(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
            //MockEmployeeRepository mockem = new MockEmployeeRepository();
            //mockem.GetEmployee(1);
            //_employeeRepository.GetEmployee(1);
        }
        public ViewResult Index()
        {
            var Empmodel = _employeeRepository.GetAllEmployee();
            return View(Empmodel);
        }

        public ViewResult Details(int Id)
        {
            
            HomeDetailsViewModel homeDetailsViewModel = new HomeDetailsViewModel()
            {
                //Test GitHub
                Employee = _employeeRepository.GetEmployee(Id),
                PageTitle = "Employee Details"
            };
            return View(homeDetailsViewModel);

        }
       
        [HttpGet]
        public ViewResult Create()
        {
            return View();
        }
        [Authorize]
        [HttpPost]
        public IActionResult Create(Employee employee)
        {
            if (ModelState.IsValid)
            {
                Employee newemployee = _employeeRepository.AddEmployee(employee);
                return RedirectToAction("Details", "home", new { id = newemployee.Id });
            }
            return View();
        }
        [Authorize]
        [HttpGet]
        public ViewResult Edit(int Id)
        {
            Employee newemployee = _employeeRepository.GetEmployee(Id);
            return View(newemployee);
        }
        [Authorize]
        [HttpPost]
        public IActionResult Edit(Employee employee)
        {
            if (ModelState.IsValid)
            {
                Employee newemployee = _employeeRepository.Update(employee);
                return RedirectToAction("Details", "home", new { id = newemployee.Id });
            }
            return View();
        }
    }
}
