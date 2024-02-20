using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCDemo.Controllers
{
    public class DemoController : Controller
    {
        //we get request from client to Controller if required it will go to model to fetch data then return with data to controller 
        //Then controller display the data in View.
        //Now the question is how controller display data in  view
        //There are certain ways like ViewData,ViewBag,TempData,Session throuhg which we can do that

        //ViewData:
        //1.Property of ControllerBase Class
        //2.System.Web.Mvc
        //3.Is of type ViewDataDictionary
        //4.ICollection<string,object>
                //ViewData.Add("Key",Value);
                 //OR,  ViewData["Key"] = value;
        //5.Drawback1: It can store complex values but can't return them directly on callback.It requires conversion.
        //6. Drawback2: It is available only for current request.


        //ViewBag:
        //1.mostly same as ViewData
        //2.it is of type "dynamic"(therefore we don't need conversion)
        //3.ViewBag can directly  return complex values on callback
        //4.ViewBag is available only for current request
        public ViewResult Index()
        {
            //ViewData
            //string name = "john";//will pass this to view through viewdata
            //ViewData["name"] = name;
            //ViewData["products"] 1zq4ze new List<string>() { "samsing tv", "apple tv", "sony tv" };//applied drawback1

            //ViewBag
            ViewBag.names = "David";
            ViewBag.categories = new List<string>() {"Apple TV","samsung TV" };
            return View();
        }
    }
}