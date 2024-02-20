using Microsoft.AspNetCore.Mvc;

namespace ClientAccessingWantDataThroughWebApi.Controllers
{
    public class MyController : Controller
    {
        public IActionResult Index()
        {
            return View("MyPage"); // Assuming your HTML file is named MyPage.html
        }
    }
}
