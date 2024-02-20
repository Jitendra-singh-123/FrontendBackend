using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OurProject
{
    [TestFixture]
    class SignInTest
    {
        SignIn signIn;
        [SetUp]
        public void SetUp()
        {
             signIn = new SignIn();
        }
        [Test]
        public void AuthTest()
        {
            string passResult = "Signin success";
            string failedResult = "Signin Failed";
            string nullResult = "Please provide username and password first";
            
            Assert.AreEqual(passResult, signIn.Authentication("sam1256", "sam@1256"));
            Assert.AreEqual(failedResult, signIn.Authentication("ravi256", "ravi@1256"));
            Assert.AreEqual(nullResult, signIn.Authentication("", "ravi@"));

        }
    }
}
