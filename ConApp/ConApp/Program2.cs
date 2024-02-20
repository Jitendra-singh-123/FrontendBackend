using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConApp
{
    class Program2
    {
        static void Main()
        {
            OurClass ourClass = new OurClass();
            ((Interface1)ourClass).Display();
            ((Interface2)ourClass).Display();
            Console.Read();
        }
    }
}
