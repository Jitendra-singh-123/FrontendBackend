using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OurProject
{
    public class SignIn
    {
        public string Authentication(string username,string password)
        {
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
                return "Please provide username and password first";
            else
            {
                if (username == "sam1256" && password == "sam@1256")
                    return "Signin success";
                else
                    return "Signin Failed";
            }
        }
    }
}
