using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    public class Calcli
    {
        public void Add(int n1,int n2)
        {
            Console.WriteLine("Addition: " + (n1+n2));
        }
        public void Subtraction(int n1, int n2)
        {
            Console.WriteLine("Subtraction: " + (n1 - n2));
        }
        public void Multiplication(int n1, int n2)
        {
            Console.WriteLine("Multiplication: " + (n1 * n2));
        }

    }
}
