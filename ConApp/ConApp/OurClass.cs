using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConApp
{
    public class OurClass : Interface1, Interface2
    {
         void Interface1.Display()
        {
            Console.WriteLine("display method of interface 1");
        }

        void Interface2.Display()
        {
            Console.WriteLine("display method of interface 2");

        }

    }
}
