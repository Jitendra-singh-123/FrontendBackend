using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCDemo.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ViewResult Index()
        {
            return View();
        }

        //PartialVieResult :
        //--Represent a base class that is used to render a partial view to the repsonse.
        //-PartialView is similar to a web user control
        //--It is a resuable prototype that can be accessed and used in any another view

        //the methods that are used to access any partial view are
        //Html.Partial()
            //Method that returns HtmlString
            //Rendered Patial View Result can be stored in HtmlString
            //Can Cache the result so that we can access them wihtout going to Server thus reduces burden on server
            //Round Trip
            //Slow in access
        //Html.RenderPartial()
            //Method without any return value
            //Directly render a string to response
            //Can't be cached
            //No round trip
            //Faster
        //Main moto to create PartialViewResult is to deisgn a useable prototype so that we can use it anywhere

        public PartialViewResult Login()
        {
            return PartialView();
        }
    }
}