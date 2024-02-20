using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NunitConstraint
{
    class Calc
    {
        public int Add()
        {
            return 10 + 30;
        }
        public int MethodWithException()
        {
            throw new Exception("I am throwing exception");
        }
    }
}
