using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShapeAreaLib
{
   public class Square
    {
       
        public double Area(double Side)
        {
            return Side * Side;
        }
        public double Perimeter(double Side)
        {
            return 4 * Side;
        }
    }
}
