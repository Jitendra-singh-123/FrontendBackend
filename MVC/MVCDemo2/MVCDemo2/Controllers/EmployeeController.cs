using Microsoft.AspNetCore.Mvc;
using MVCDemo2.Models;

namespace MVCDemo2.Controllers
{
    public class EmployeeController : Controller
    {

        static List<Employee> employeesList = new List<Employee>()
        {
            new Employee(){Id = 1,Name ="Rahul",Designation="Manager",Salary = 98000,DOJ = new DateTime(day:12,month:1,year:2021)},
            new Employee(){Id = 2,Name ="Amit",Designation="Developer",Salary = 88000,DOJ = new DateTime(day:13,month:4,year:2021)},
            new Employee(){Id = 3,Name ="Raj",Designation="Developer",Salary = 78000,DOJ = new DateTime(day:8,month:2,year:2021)},
            new Employee(){Id = 4,Name ="Vini",Designation="Tester",Salary = 68000,DOJ = new DateTime(day:25,month:7,year:2021)},
        };
        public IActionResult Index()
        {
            return View(employeesList);
        }

        //Used to show Create page
        [HttpGet]
        public IActionResult Create()
        {
            return View(new Employee());
        }

        
        [HttpPost]
        public IActionResult Create(Employee employee)
        {
            if (employee != null)
            {

                //// Check if an employee with the same ID already exists
                //if (employeesList.Exists(e => e.Id == employee.Id))
                //{
                //    // If an employee with the same ID exists, show an error message
                //    ModelState.AddModelError("Id", "Employee with this ID already exists.");
                //}

                if (ModelState.IsValid)
                {
                    employeesList.Add(employee);
                    // Assuming you want to redirect to a different action after successfully adding the employee
                    return RedirectToAction("Index"); // Replace "Index" with the name of your action method
                }
            }

            // If ModelState is not valid or employee is null, return the same view with validation errors
            return View(employee); // You need to have a corresponding view for the Create action

        }
    }
}
