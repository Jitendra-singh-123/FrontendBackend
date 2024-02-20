using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCDemo.Models;
namespace MVCDemo.Controllers
{
    //sometime we want to send our MVC application data to other Application then can share the JSON File
    //Here we want that our MVC data to provided in other applications like mobile application
    //So to achieve we shared the data either in XML or JSON Form

    public class DemoForJSONController : Controller
    {
        List<Product> products = new List<Product>()
        {
            new Product { ProductId = 1,Name = "Samsung TV",Price = 70000M},
            new Product { ProductId = 2,Name = "LG TV",Price = 79000M}
        };
        public JsonResult ProductsData()
        {
            //returns the data in JSON form if request is Get
            return Json(products,JsonRequestBehavior.AllowGet);
        }
    }
}