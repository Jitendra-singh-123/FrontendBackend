using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShapeAreaLib
{
   public class Triangle
    {
       public double Area(double Height,double Base)
        {
            return 0.5 * Base * Height;
        }
        public double Perimeter(double Base, double Side1,double Side2)
        {
            return Base + Side1 + Side2;
        }
    }
}
