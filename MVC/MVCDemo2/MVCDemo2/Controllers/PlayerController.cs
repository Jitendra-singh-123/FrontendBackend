using Microsoft.AspNetCore.Mvc;
using MVCDemo2.Models;

namespace MVCDemo2.Controllers
{
    public class PlayerController : Controller
    {
        static List<Player> playerList = new List<Player>()
        {

        };
        public IActionResult Index()
        {
            return View();
        }
       
        public IActionResult Display()
        {
            return View(playerList);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Player player) {
            if (ModelState.IsValid)
            {
                playerList.Add(player);
                return Redirect("Display");
            }
            return View();
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
          //  var player = playerList[id];
            var player = playerList.FirstOrDefault(x=>x.Id == id);

            if(player == null)
                return NotFound();//404 error
            return View(player);

        }

        [HttpPost]
        public IActionResult Edit(Player player)
        {
            //  var player = playerList[id];
            var existPlayer = playerList.FirstOrDefault(x => x.Id == player.Id);

            if (existPlayer == null)
                return NotFound();//404 error

            else
            {
                existPlayer.Name = player.Name;
                existPlayer.Description = player.Description;

            }

            return RedirectToAction("Display");

        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            //  var player = playerList[id];
            var player = playerList.FirstOrDefault(x => x.Id == id);

            if (player == null)
                return NotFound();//404 error
            return View(player);

        }


        [HttpPost]
        public IActionResult Delete(Player player)
        {
            //  var player = playerList[id];
            var existPlayer = playerList.FirstOrDefault(x => x.Id == player.Id);

            if (existPlayer == null)
                return NotFound();//404 error

            else
            {
                playerList.Remove(existPlayer);

            }

           return RedirectToAction("Display");

        }


        [HttpGet]
        public IActionResult Details(int id)
        {
            //  var player = playerList[id];
            var player = playerList.FirstOrDefault(x => x.Id == id);

            if (player == null)
                return NotFound();//404 error
            return View(player);

        }

    }
}
