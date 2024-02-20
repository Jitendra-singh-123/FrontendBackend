using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OurProject
{
    class ShapeAreaLib
    {
        public double RectangleArea(double l,double b)
        {
            return l * b;
        }
        public double SquareArea(double s)
        {
            return s * s;
        }
        public double CircleArea(double r)
        {
            return 3.14 * r * r;
        }
        public double TraingleArea(double b,double h)
        {
            return 0.5 * b * h;
        }
    }
}
