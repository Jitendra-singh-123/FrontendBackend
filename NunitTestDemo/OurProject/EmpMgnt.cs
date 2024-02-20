using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OurProject
{
   public class EmpMgnt
    {
        static List<Emp> empsList = new List<Emp>()
        {
            new Emp{Id = 1,Name = "Sam",Salary = 90000,Designation = "Manager"},
            new Emp{Id = 2,Name = "Rahul",Salary = 80000,Designation = "Developer"},
            new Emp{Id = 3,Name = "Jack",Salary = 60000,Designation = "Tester"},
            new Emp{Id = 4,Name = "Jyoti",Salary = 45000,Designation = "HR"},
            new Emp{Id = 5,Name = "Hrtitk",Salary = 95000,Designation = "Develpor"},

        };

        public List<Emp> AllEmps()
        {
           
            return empsList;
        }

        public List<Emp> EmpById(int id)
        {
            List<Emp> searchList = new List<Emp>();
            foreach(Emp emp in empsList)
            {
                if (emp.Id == id)
                    searchList.Add(emp);
            }
            return searchList;
        }
        public int SalaryDivision(int a,int b)
        {
            return a / b;
        }
    }
}
