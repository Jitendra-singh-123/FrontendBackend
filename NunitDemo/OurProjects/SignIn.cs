using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OurProjects
{
    public class SignIn
    {
        public string Authentication(string username, string password)
        {
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
                return "Please Provide Username and Password first";
            else
            {
                if (username == "sam1256" && password == "sam@1256")
                    return "Sign In success";
                else
                    return "Sign In Failed";
            }
        }
    }
}
