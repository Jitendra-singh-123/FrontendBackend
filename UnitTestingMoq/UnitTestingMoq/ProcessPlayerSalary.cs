using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestingMoq
{
   public class ProcessPlayerSalary
    {
        //dependency injection using property
        public bool CreditSalary(CheckPlayer checkPlayer)
        {
            checkPlayer.isExist();//using CheckPlayer Service here, if any error comes here because of that i am unable to test the Credit Salary method for that i use moq and will mock the checkplayer and then use setup to by pass the isExist method so that our Credit salary is properly tested.

            //some credit logic is here and then returning value
            return true;
        }
    }
}
