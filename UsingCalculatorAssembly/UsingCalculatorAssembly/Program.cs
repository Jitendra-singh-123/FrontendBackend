using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Calculator;

namespace UsingCalculatorAssembly
{
    class Program
    {
        static void Main(string[] args)
        {
            Calcli calcli = new Calcli();
            calcli.Add(2, 3);
            Console.Read();
        }
    }
}
