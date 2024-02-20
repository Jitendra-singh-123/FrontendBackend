using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDDUnitTesting
{
    public class Calculation
    {
        public int Add(int n1,int n2)
        {
            return n1 + n2;
        }

        public int Multiply(int n1, int n2)
        {
            return n1 * n2;
        }

        //roots
        public int Square(int n)
        {
            
            return n * n;
        }

        public int SquareRoot(int n)
        {

            return (int)Math.Sqrt(n);
        }
        public int Cube(int n)
        {

            return n * n * n;
        }
    }
}
