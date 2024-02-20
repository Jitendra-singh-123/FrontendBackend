using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OurProject
{
    [TestFixture]
    class ShaprAreaLibTest
    {
        ShapeAreaLib shapeAreaLib;
        [SetUp]
        public void SetUp()
        {
            shapeAreaLib = new ShapeAreaLib();
        }

        [Test]
        public void TestAreas()
        {
            Assert.AreEqual(shapeAreaLib.CircleArea(2),12.56);
            Assert.AreEqual(4,shapeAreaLib.RectangleArea(2,2));
            Assert.AreEqual(4,shapeAreaLib.SquareArea(2));
            Assert.AreEqual(2,shapeAreaLib.TraingleArea(2,2));
        }
    }
}
