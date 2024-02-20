using Microsoft.AspNetCore.Mvc;
using MVCDemo2.Models;
using static System.Net.WebRequestMethods;
using System.Drawing;
using System.Runtime.Intrinsics.X86;
using System.Security.Cryptography.Xml;

namespace MVCDemo2.Controllers
{
    public class CustomerController : Controller
    {
        static List<Customer> customersList = new List<Customer>()
        {
            new Customer() { CustomerId = 1, Name = "Rahul",CEmail="Rahul@gmail.com",OverDraftLimit = 12000},
            new Customer() { CustomerId = 2, Name = "Jaya",CEmail="Jaya@gmail.com",OverDraftLimit = 22000},
            new Customer() { CustomerId = 3, Name = "Nikita",CEmail="Nikita@gmail.com",OverDraftLimit = 10000},

        };

        public IActionResult Login()
        {
            return View();
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Display() {
            ViewBag.msg = "Welcome to customer Page";
            ViewBag.noCust ="Number of Customer are : " + customersList.Count;
            ViewData["msg"] = "Enjoye the Customer Service";//Drawback need conversion for complex type in views
            return View(customersList);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View(new Customer());
        }

        [HttpPost]
        public IActionResult Create(Customer customer)
        {
            if (customer.CustomerId < 0)
            {
                //server side validation using customer validation
                ModelState.AddModelError("Custom Error", "Customer Id should not be negative");
            }
          

            //server side validation
            if (ModelState.IsValid)
            {
                customersList.Add(customer);
                //TempData is similar to ViewData, but it persists for a subsequent HTTP request.This means that you can use TempData to transfer data between two successive requests, typically between actions or controllers.
                TempData["msg"] = "New Customer Registration successful";
                return RedirectToAction("Display");
            }
            return View();
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {

            var customer = customersList.FirstOrDefault(x => x.CustomerId == id);
            if (customer == null)
                return NotFound();//404 error
            return View(customer);
        }

        [HttpPost]
        public IActionResult Edit(Customer customer)
        {
            //  var player = playerList[id];
            var existCustomer = customersList.FirstOrDefault(x => x.CustomerId == customer.CustomerId);

            if (existCustomer == null)
                return NotFound();//404 error

            else
            {
                existCustomer.Name = customer.Name;
                existCustomer.CEmail = customer.CEmail;

            }

            return RedirectToAction("Display");

        }



        [HttpGet]
        public IActionResult Delete(int id)
        {
            //  var player = playerList[id];
            var customer = customersList.FirstOrDefault(x => x.CustomerId == id);

            if (customer == null)
                return NotFound();//404 error
            return View(customer);

        }


        [HttpPost]
        public IActionResult Delete(int? id)
        {
            //  var player = playerList[id];
            var existCustomer = customersList.FirstOrDefault(x => x.CustomerId == id);

            if (existCustomer == null)
                return NotFound();//404 error

            else
            {
                customersList.Remove(existCustomer);

            }

            return RedirectToAction("Display");

        }


        [HttpGet]
        public IActionResult Details(int id)
        {
            //  var player = playerList[id];
            var customer = customersList.FirstOrDefault(x => x.CustomerId == id);

            if (customer == null)
                return NotFound();//404 error
            return View(customer);

        }

    }
}
