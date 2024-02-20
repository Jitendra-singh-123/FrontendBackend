using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace UnitTestProject
{
    [TestClass]
    public class UnitTest1
    {
        

        [TestMethod]
        public void AddTest()
        {
            int n1 = 12;
            int n2 = 2;
            int res = 7;
            Calculation calculation = new Calculation();
            Assert.AreEqual(res,calculation.Average(n1,n2));
        }
        

    }
}
