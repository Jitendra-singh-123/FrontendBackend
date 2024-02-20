using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebExercise.Models;

namespace WebExercise.Controllers
{
    public class StudentController : Controller
    {

        static List<Student> studentsList = new List<Student>()
        {
            new Student(){SId=1,SName="Rahul",SFee=1200,SPassword="rahul@123"},
            new Student(){SId=2,SName="Jay",SFee=1300,SPassword="jay@123"},
            new Student(){SId=3,SName="Rohit",SFee=1600,SPassword="rohit@123"},

        };
     

        public IActionResult Index()
        {

            return View();
        }
        public IActionResult Display()
        {
            
            return View(studentsList);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View(new Student());
        }

        [HttpPost]
        public IActionResult Create(Student students)
        {
            if (ModelState.IsValid)
            {
                studentsList.Add(students);
                //TempData is similar to ViewData, but it persists for a subsequent HTTP request.This means that you can use TempData to transfer data between two successive requests, typically between actions or controllers
                return RedirectToAction("Display");
            }
            return View();
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var student = studentsList.FirstOrDefault(x => x.SId == id);
            if (student == null)
                return NotFound();//404 error
            return View(student);
        }

        [HttpPost]
        public IActionResult Edit(Student student)
        {
            //  var player = playerList[id];
            var existStudent = studentsList.FirstOrDefault(x => x.SId == student.SId);

            if (existStudent == null)
                return NotFound();//404 error

            else
            {
                existStudent.SName = student.SName;
                existStudent.SFee = student.SFee;



            }

            return RedirectToAction("Display");

        }



        [HttpGet]
        public IActionResult Delete(int id)
        {
            //  var player = playerList[id];
            var student = studentsList.FirstOrDefault(x => x.SId == id);

            if (student == null)
                return NotFound();//404 error
            return View(student);

        }


        [HttpPost]
        public IActionResult Delete(int? id)
        {
            //  var player = playerList[id];
            var existStudent = studentsList.FirstOrDefault(x => x.SId == id);

            if (existStudent == null)
                return NotFound();//404 error

            else
            {
                studentsList.Remove(existStudent);

            }

            return RedirectToAction("Display");

        }


    }
}
