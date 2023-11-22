using Microsoft.AspNetCore.Mvc;
using MvcApp.Models;

namespace MvcApp.Controllers
{
    public class EmployeeController : Controller
    {
        //GET ALL

        [HttpGet("/employee")]
        public IActionResult GetAllEmployee()
        {
            var emp = EmployeeOperations.GetAllEmployee();
            return View("EmployeeList", emp);
        }

        //CREATE

        [HttpGet("/create")]
        public IActionResult Create()
        {
            return View("Create", new Employee());
        }
        [HttpPost("/create")]
        public IActionResult Create([FromForm] Employee e)
        {
            EmployeeOperations.CreateNew(e);
            return View("EmployeeList", EmployeeOperations.GetAllEmployee());
        }

        //EDIT

        [HttpGet("/edit/{pEmpId}")]
        public IActionResult EditEmployee(int pEmpId)
        {
            var found = EmployeeOperations.Search(pEmpId);
            return View("Edit", found);
        }
        [HttpPost("/edit/{pEmpId}")]
        public IActionResult EditEmployee(int pEmpId, [FromForm] Employee e)
        {
            var found = EmployeeOperations.Search(e.EmpId);
            found.Designation = e.Designation;
            found.Salary = e.Salary;
            found.EmpName = e.EmpName;
            found.IsActive= e.IsActive;
            return View("EmployeeList", EmployeeOperations.GetAllEmployee());
        }

        //DETAILS

        [HttpGet("/search/{pEmpId}")]
        public IActionResult EmpDetails(int pEmpId)
        {
            var found = EmployeeOperations.Search(pEmpId);
            return View("Search", found);
        }
        [HttpGet("/empfromdb")]
        public IActionResult DBData()
        {
            var found = EmpLib.Employee.Get();
            return View("dbview", found);
        }

    }
}
