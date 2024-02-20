using Microsoft.AspNetCore.Mvc;

namespace MVCDemo2.Controllers
{
    public class DemoController1 : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
