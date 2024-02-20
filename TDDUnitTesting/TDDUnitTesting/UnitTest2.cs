using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDDUnitTesting
{
    [TestClass]
    class UnitTest2
    {
        Root root = new Root();

        [TestMethod]
        public void SquareTest()
        {
            int n = 2;
            int res = 4;
            Assert.AreEqual(root.Square(n),res);
        }
        [TestMethod]
        public void SquareRootTest()
        {
            int n = 4;
            int res = 2;
            Assert.AreEqual(root.Square(n), res);
        }
        [TestMethod]
        public void CubeTest()
        {
            int n = 2;
            int res = 8;
            Assert.AreEqual(root.Square(n), res);
        }
    }
}
