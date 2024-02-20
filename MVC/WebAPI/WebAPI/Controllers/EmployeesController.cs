using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        static List<Employee> employeesList = new List<Employee>()
        {
            new Employee() { Id = 1,Fname="Sam",Lname="Dicosta",Salary=98000.90},
            new Employee() { Id = 2,Fname="Nitin",Lname="Vats",Salary=88000.90},
            new Employee() { Id = 3,Fname="Vikas",Lname="Goyal",Salary=76000.90},
            new Employee() { Id = 4,Fname="Sameer",Lname="Khan",Salary=85000.20},
            new Employee() { Id = 5,Fname="Deep",Lname="Das",Salary=65000.90},
            new Employee() { Id = 6,Fname="Arsh",Lname="Man",Salary=55000.90},
            new Employee() { Id = 7,Fname="Danish",Lname="Waani",Salary=91000.90},
        };

        [HttpGet(Name = "GetEmployee")]
        public IEnumerable<Employee> Get()
        {
            return employeesList;
        }

        [HttpGet("{id}")]
        public ActionResult<Employee> Get(int id)
        {
            Employee emp = employeesList.SingleOrDefault(e => e.Id == id);
            if (emp == null)
                return NotFound();
            else
                return Ok(emp);
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            Employee emp = employeesList.SingleOrDefault(e => e.Id == id);
            if (emp == null)
                return NotFound();
            else
            {
                employeesList.Remove(emp);
                return NoContent();
            }


        }

        [HttpPost]
        public ActionResult<Employee> Post(Employee employee)
        {
            employeesList.Add(employee);
            return CreatedAtAction(nameof(Get), employee);
        }

        [HttpPut("{id}")]
        public ActionResult<Employee> Put(int id,Employee employee)
        {
            Employee empExist = employeesList.SingleOrDefault(e => e.Id == id);
            if (empExist == null)
                return NotFound();
            else
            {
                empExist.Fname = employee.Fname;
                empExist.Lname= employee.Lname;
                empExist.Salary = employee.Salary;
                return NoContent();
            }
        }

    }
}
