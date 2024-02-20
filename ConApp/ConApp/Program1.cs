using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConApp
{
    class Program1
    {
        public static void Main()
        {
            Employee1 employee1 = new Employee1();
            employee1.Id = 4;
            employee1.Name = "Rahul";
            employee1.Salary = 45550.22;
            Console.WriteLine("Employee Details:");
            Console.WriteLine("Employee Id : " + employee1.Id);
            Console.WriteLine("Employee Name: " + employee1.Name);
            Console.WriteLine("Employee Salary: " + employee1.Salary);

            Employee1 employee11 = new Employee1() { 
                Id = 7,
                Name = "Jitendra",
                Salary = 239000
            };

            Console.WriteLine("\nEmployee Details:");
            Console.WriteLine("Employee Id : " + employee11.Id);
            Console.WriteLine("Employee Name: " + employee11.Name);
            Console.WriteLine("Employee Salary: " + employee11.Salary);

            Console.WriteLine("\nNumber of employee: " + Employee1.count);

            Console.ReadLine();
        }
    }
}
