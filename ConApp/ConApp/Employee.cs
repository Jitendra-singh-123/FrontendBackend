using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConApp
{

   public class Employee
    {
        public Employee()
        {
            salary = 45000;
        }
        //read write
        private string name;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        //auto implemented
        public int Id { get; set; }
        public int Age { get; set; }
        public DateTime DOJ { get; set; }

        //read
        private double salary;

        public double Salary
        {
            get { return salary; }
           
        }

        //static property
        private static double tax;

        public static double Tax 
        {
            get { return tax; }
            set { tax = value; }
        }



    }
}
