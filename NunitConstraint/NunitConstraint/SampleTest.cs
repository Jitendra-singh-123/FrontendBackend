using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NunitConstraint
{
    [TestFixture]
    class SampleTest
    {
        Calc calc;
        [SetUp]
        public void SetUp()
        {
            calc = new Calc();
        }
        [Test]
        public void SubSetTest()
        {
            List<string> colorsList = new List<string>() {"Red", "Blue","Green","White","Pink","Yellow" };
            List<string> favColorsList = new List<string>() {"Blue","White" };
            Assert.That(favColorsList, Is.SubsetOf(colorsList));
        }
        [Test]
        public void SuperSetTest()
        {
            List<string> colorsList = new List<string>() { "Red", "Blue", "Green", "White", "Pink", "Yellow" };
            List<string> favColorsList = new List<string>() { "Blue", "White" };
            Assert.That(colorsList, Is.SupersetOf(favColorsList));
        }

        public void TestWithExceptionNoExConstraint()
        {
            Assert.That(()=>calc.Add(),Throws.Nothing);
        }
        [Test]
        public void DecimalPlacesTest()
        {
            double expectedValue = 22.12345;
            double actualValue = 22.1234;
            Assert.AreEqual(actualValue,expectedValue);
        }
        [Test]
        //Constraints in NUnit are used within Assert.That() statements to define conditions that the actual value being tested must satisfy. 
        public void DecimalPlacesTestWithConstraintIgnoreDecimals()
        {
            double expectedValue = 22.12345;
            double actualValue = 22.1234;
            //In this example, Is.EqualTo() is constraints used within Assert.That() to express different conditions.
            Assert.That(actualValue, Is.EqualTo(expectedValue).Within(0.01));

        }
    }
}
