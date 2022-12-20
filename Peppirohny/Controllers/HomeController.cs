using Interfaces;
using Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Peppirohny.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Peppirohny.Models.Home;

namespace Peppirohny.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private IUserBLL _userBLL;
        private IGameBLL _gameBLL;

        public HomeController(ILogger<HomeController> logger, IUserBLL usersBLL, IGameBLL gameBLL)
        {
            _logger = logger;
            _userBLL = usersBLL;
            _gameBLL = gameBLL;
        }

        [Authorize]
        public IActionResult Index(int id, string name)
        {
            TempData["Success"] = "Success";

            if (User.Identity.IsAuthenticated)
            {
                var userName = User.Identity.Name;
            }

            return View("Index");
        }


        public IActionResult Privacy()
        {
            return Json(new { Id = 420, Name = "AAA product without any privacy" });
        }


        public IActionResult Info()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpGet]
        [Authorize]
        public IActionResult StartGame()
        {
            Game newGame = new Game();
            GameModel gameModel = new GameModel()
            {
                score = 0,
                playDate = DateTime.Now,
                userID = _userBLL.GetByLogin(User.Identity.Name).id
            };
            return View(gameModel);
        }

        [HttpPost]
        [Authorize]
        public IActionResult SaveGame(int score)
        {
            Game game = new Game()
            {
                score = score,
                playDate = DateTime.Now,
                userID = _userBLL.GetByLogin(User.Identity.Name).id
            };
            _gameBLL.PutGame(game);

            return RedirectToAction("StartGame", "Home");
        }
    }
}
