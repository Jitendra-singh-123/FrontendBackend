using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmployeeLib;
namespace LibraryUsuage
{
    public static class OurClass
    {
        public static string Welcome(this EmployeeManagement obj,string name)
        {
            return "Welcome to Employee Management " + name; 
        }
        public static void Delete(this EmployeeManagement obj, int id)
        {
            Employee emp = EmployeeManagement.empList.Find(e => e.Id == id);
            if (emp != null)
            {
                EmployeeManagement.empList.Remove(emp);
                Console.WriteLine("Employee Record Deleted");
                Console.WriteLine("After  Deletion Employee List");
                obj.Display();
            }
            else
                Console.WriteLine($"No such Employee ID: {id} exists");
        }
    }
   
    internal class Program
    {
        static void Main(string[] args)
        {
            EmployeeManagement employeeManagement = new EmployeeManagement();
            Console.WriteLine("Enter your name");
            Console.WriteLine(employeeManagement.Welcome(Console.ReadLine()));
            Console.WriteLine("Choose operation \n1.Display \n2.Search \n3.Delete");
            int op = int.Parse(Console.ReadLine());

            switch (op)
            {
                case 1:
                    employeeManagement.Display();
                    break;
                case 2:
                    Console.WriteLine("Enter the Employee Id");
                    int id = int.Parse(Console.ReadLine());
                    employeeManagement.SearchEmployee(id);
                    break;
                case 3:
                    Console.WriteLine("Enter employee Id to delete");
                    int Id = int.Parse(Console.ReadLine());
                    employeeManagement.Delete(Id);
                    break;
                default:
                    Console.WriteLine("Wrong operation selected");
                    break;
            }

            Console.ReadLine();
        }
    }
}
