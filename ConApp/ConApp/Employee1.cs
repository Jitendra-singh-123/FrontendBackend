using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConApp
{
    class Employee1
    {
        private string name;
        public static int count = 0;
        public Employee1()
        {
            count++;
        }
        public int Id { get; set; }
        public string Name { 
            get { return name; }
            set
            {
                if (6 < value.Length)
                    name = value;
                else
                    name = "Invalid Name";
            }
        }
        public double Salary { get; set; }
    }
}
