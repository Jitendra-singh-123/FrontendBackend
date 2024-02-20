using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestingMoq
{
    class MathOperation
    {
        readonly ICalc calc;
        //dependecncy injection use
        public MathOperation(ICalc calc)
        {
            this.calc = calc;
        }
        public int MultiplyAdd(int num1,int num2,int num3) 
        {
            return calc.Add(num1, num2) * num3;
        }
    }
}
