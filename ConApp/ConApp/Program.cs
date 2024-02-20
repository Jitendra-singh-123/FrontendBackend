using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConApp
{
    class Program
    {
        public static void Main()
        {
            //Employee employee = new Employee();
            //Console.WriteLine("Enter employee name");
            //employee.Name = Console.ReadLine();
            ////Console.WriteLine("Employee Salary");
            //// error property is readonly -->  employee.Salary = double.Parse(Console.ReadLine);
            //Console.WriteLine("Enter Tax");
            //Employee.Tax = double.Parse(Console.ReadLine());
            //Console.WriteLine("Employee Details as follows");
            //Console.WriteLine("Name : " + employee.Name);
            //Console.WriteLine("Salary : " + employee.Salary);
            //Console.WriteLine("Tax : " + Employee.Tax);

            //For auto implemented
            Employee employee1 = new Employee() {
                Id = 4,
                Age = 28,
                DOJ = new DateTime(day: 12, month: 12,year: 2023),
                Name = "Rahul",

            };
            Console.WriteLine("Employee Details:");
            Console.WriteLine("Employee Id: " + employee1.Id);
            Console.WriteLine("Employee Age: " + employee1.Age);
            Console.WriteLine("Employee DOJ: " + employee1.DOJ);
            Console.WriteLine("Employee Name: " + employee1.Name);
            Console.ReadLine();
        }
    }
}
