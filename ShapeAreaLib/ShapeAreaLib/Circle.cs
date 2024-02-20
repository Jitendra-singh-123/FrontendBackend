using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShapeAreaLib
{
    public class Circle
    {
     
        public double Area(double Radius)
        {
            return 3.14 * Radius * Radius;
        }
        public double Perimeter(double Radius)
        {
            return 2 * 3.14 * Radius;
        }
    }
}
