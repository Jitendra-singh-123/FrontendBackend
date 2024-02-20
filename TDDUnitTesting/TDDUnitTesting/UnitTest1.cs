using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace TDDUnitTesting
{
    //Test Driven Development is the process in which test cases are written before the code that validates those cases. It depends on repetition of a very short development cycle.

                    //              ----------------------------------
                    //              |                               |
                    //            Red ---------> Green --------->Refactor
                
    //step1 :Red – Create a test case and make it fail
    //step2: Green – Make the test case pass by any means.
    //step3: Refactor – Change the code to remove duplicate/redundancy.
    [TestClass]
    public class UnitTest1
    {
        Calculation calculation = new Calculation();//Here we don't first create the Calculation class and then run it, when the test case fails then we add the Calculation class
        Root root = new Root();
        [TestMethod]
        public void AddTest()
        {
            int num1 = 10;
            int num2 = 20;
            int result = 30;
            Calculation calculation = new Calculation();
            Assert.AreEqual(result, calculation.Add(num1,num2));
        }

        [TestMethod]
        public void MultiplyTest()
        {
            int num1 = 10;
            int num2 = 20;
            int result = 200;
            
            Assert.AreEqual(result, calculation.Multiply(num1, num2));
        }



        [TestMethod]
        public void SquareTest()
        {
            int n = 2;
            int res = 4;
            Assert.AreEqual(res,root.Square(n));
        }
        [TestMethod]
        public void SquareRootTest()
        {
            int n = 4;
            int res = 2;
            Assert.AreEqual(res,root.SquareRoot(n));
        }
        [TestMethod]
        public void CubeTest()
        {
            int n = 2;
            int res = 8;
            Assert.AreEqual(res,root.Cube(n));
        }
    }
}
