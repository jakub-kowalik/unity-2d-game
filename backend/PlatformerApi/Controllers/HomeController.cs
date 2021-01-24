using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PlatformerApi.Data;
using PlatformerApi.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace PlatformerApi.Controllers
{
    public class HomeController : Controller
    {
        private GameApiContext _context;

        private readonly ILogger<HomeController> _logger;


        public HomeController(ILogger<HomeController> logger, GameApiContext context)
        {
            _context = context;
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpPost]
        public async Task<ActionResult<GameStats>> PostTodoItem(GameStats gameStatsItem)
        {
            _context.GameStatsItems.Add(gameStatsItem);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTodoItem", new { id = gameStatsItem.Id }, gameStatsItem);
            //return CreatedAtAction(nameof(GetgameStatsItem), new { id = gameStatsItem.id }, gameStatsItem);
        }
    }
}
