using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OurProject
{
    [TestFixture]
    class EmpmgntTest
    {
        EmpMgnt mgnt;
        [SetUp]
        public void SetUp()
        {
            mgnt = new EmpMgnt();
        }

        [Test]
        public void SearchTest()
        {
            // Testing for employee id 3{Id = 3,Name = "Jack",Salary = 60000,Designation = "Tester"},

            var empList = mgnt.EmpById(3);
            foreach (var emp in empList)
            {
                Assert.AreEqual(3, emp.Id);
                Assert.AreEqual("Jack", emp.Name);
                Assert.AreEqual(60000, emp.Salary);
                Assert.AreEqual("Tester", emp.Designation);
            }
        }

        [Test]
        public void IsNotNullTest()
        {
            foreach (var emp in mgnt.AllEmps()) 
            {
                Assert.IsNotNull(emp.Id);
            }
        }

        [Test]
        public void DivideByZeroTest()
        {
            Assert.Throws<DivideByZeroException>(() => mgnt.SalaryDivision(10,0));
        }
    }
}
