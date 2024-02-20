using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace OurProjects
{
    [TestFixture]
    class SignInTest
    {
        [Test]
        public void EqualTest()
        {
            int num1 = 12;
            int num2 = 12;
            Assert.That(num1, Is.EqualTo(num2));
        }
    }
}
