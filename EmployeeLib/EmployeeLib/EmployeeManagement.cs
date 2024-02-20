using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeLib
{
     public class EmployeeManagement
    {
      public  static List<Employee> empList = new List<Employee>()
        {
            new Employee(){ Id = 1, Fname = "Raj",Lname = "Singh",Salary = 23333.90},
            new Employee(){ Id = 2, Fname = "Mohan",Lname = "Singh",Salary = 783333.90},
            new Employee(){ Id = 3, Fname = "K Menon",Lname = "Rohan",Salary = 98333.90},
        };
        public void Display()
        {
            Console.WriteLine("ID \t First Name \t Last Name \t Salary ");
            foreach(Employee emp in empList)
            {
                Console.Write(emp.Id + "\t");
                Console.Write(emp.Fname + "\t");
                Console.Write(emp.Lname+ "\t");
                Console.Write(emp.Salary+ "\t");
                Console.WriteLine();

            }
        }

        public void SearchEmployee(int id)
        {
            Employee employee = empList[id];
            if(employee == null)
            {
                Console.WriteLine($"No such employee {id} exists");
            }
            else
            {
                Console.WriteLine("Record found:");
                Console.WriteLine(employee.Id + "\t");
                Console.WriteLine(employee.Fname + "\t");
                Console.WriteLine(employee.Lname + "\t");
                Console.WriteLine(employee.Salary + "\t");
            }
        }
    }
}
