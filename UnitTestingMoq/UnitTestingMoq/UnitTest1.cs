using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;

namespace UnitTestingMoq
{
    [TestClass]
    public class UnitTest1
    {

        //we use moq so that we can test classes methods separatly without any effect of other classes method
        [TestMethod]
        public void TestMockExample()
        { 
            //To use Moq please,program should have dependency injection
            //Step 1: Create Mock Object of type (which may through error, generally interface or class having virtual method)
            Mock<CheckPlayer> checkPlayer = new Mock<CheckPlayer>();
            checkPlayer.Setup(p => p.isExist()).Returns(true);//Specify which funciton you want to by Pass like here By passing isExist so that we can test Credit salary independently
            ProcessPlayerSalary processPlayerSalary = new ProcessPlayerSalary();
            Assert.AreEqual(true, processPlayerSalary.CreditSalary(checkPlayer.Object));
        }

        [TestMethod]
        public void MultiplyAddTest()
        {
            Mock<ICalc> mock = new Mock<ICalc>();
            mock.Setup(p=>p.Add(2,3)).Returns(5);
            MathOperation mathOperation = new MathOperation(mock.Object);
            int res = mathOperation.MultiplyAdd(2, 3,4);
            Assert.AreEqual(20, res);
        }
    }
}
