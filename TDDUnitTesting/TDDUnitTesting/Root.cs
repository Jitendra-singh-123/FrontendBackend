using System;

namespace TDDUnitTesting
{
    public class Root
    {
        public int Square(int n)
        {
            int res = n * n;
            return res;
        }

        public int SquareRoot(int n)
        {
            int res = (int)Math.Sqrt(n);
            return res;
        }
        public int Cube(int n)
        {
            int res = n * n * n;
            return res;
        }
    }
}