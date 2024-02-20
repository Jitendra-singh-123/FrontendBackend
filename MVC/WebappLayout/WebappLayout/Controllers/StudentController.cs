using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebappLayout.Models;

namespace WebappLayout.Controllers
{
    public class StudentController : Controller
    {

        static List<Student> studentsList = new List<Student>()
        {
            new Student(){Id=1,Name="Rahul",Age=19,Class=12},
            new Student(){Id=2,Name="Rohini",Age=18,Class=11},
            new Student(){Id=3,Name="Vivek",Age=16,Class=9},
            new Student(){Id=4,Name="Kajal",Age=21,Class=12},
        };
        // GET: StudentController
        public ActionResult Display()
        {
            return View(studentsList);
        }

        // GET: StudentController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: StudentController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: StudentController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: StudentController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: StudentController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: StudentController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: StudentController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
