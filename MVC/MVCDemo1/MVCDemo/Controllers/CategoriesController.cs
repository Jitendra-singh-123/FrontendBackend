using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCDemo.Controllers
{
    //with scofolding// just right click on controllers and then click on controller
    //first the view comes(the client  request routed to controllers) then controller will process the request invokes action and response to the request(or handles the communication between model and view)

    //Controller is a C# Class having action methods
    //action methods: Controller methods that respond to various Http verbs Like GET,POST,PUT,DELETE..
    //The request comes from Client are proccessed by action methods and these action methods will generate the response and send the response as output

    //Now how the controller recognise the action methods there are some rules for that:
    //Controller action method must be public in access
    //Controller action method can't be static
    //Controller action method  must return a value(because action method must return reponse of client request)
    //Controller action method must be defined with return type.
    //Controller action method can not be void
    //Controller action method  can be parameterless or parameterized
                //-If parameterized then params are passed into URL as QueryString
    //Controller action method can't have ref and out parameters
    //Controller action method can't have  open generic types
    //Controller action method can overload(sometimes client request for same action comes in several ways like post,get,delete,put)
    //Controller action method  can not override and can't be any extension method
    //Controller action method can't ne any method of controller base class
    public class CategoriesController : Controller
    {
        
    }
}