using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PlatformerApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace PlatformerApi.Controllers
{
    [ApiController]
    public class GameStatsController : Controller
    {
        private readonly GameApiContext _context;

        public GameStatsController(GameApiContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("~/GameStats/GetAll")]
        public async Task<List<GameStats>> Index()
        {
            return await _context.GameStatsItems.ToListAsync();
        }

        [HttpGet]
        [Route("~/GameStats/Get/{id}")]
        public async Task<GameStats> GetGameStats(long id)
        {
            return await _context.GameStatsItems.FindAsync(id);
        }

        [HttpGet]
        [Route("~/GameStats/Level/{lvl}/Get10Sorted")]
        public async Task<List<GameStats>> GetGameStatsByLvlDescendingTop10(string lvl)
        {
            return await _context.GameStatsItems
                .Where(o => o.Level == int.Parse(lvl))
                .OrderByDescending(x => x.Points)
                .Take(10)
                .ToListAsync();
        }

        [HttpGet]
        [Route("~/GameStats/GetPlayerStats/{id}")]
        public async Task<List<GameStats>> GetAllStatsByPlayerName(string id)
        {
            return await _context.GameStatsItems.Where(name => name.PlayerName == id).ToListAsync();
        }
        // [Bind("Id,PlayerName,Points,Level")]

        [HttpPost]
        [Route("~/GameStats/Create")]
        public async Task<IActionResult> Create([FromBody] GameStats gameStats)
        {
            if (ModelState.IsValid)
            {
                System.Diagnostics.Debug.WriteLine("Item id= " + gameStats.Id + "," + gameStats.PlayerName + "," + gameStats.Points);
                _context.Add(gameStats);
                await _context.SaveChangesAsync();
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        //[Bind("Id,PlayerName,Points,Level")]
        [HttpPut]
        //[ValidateAntiForgeryToken]
        [Route("~/GameStats/Edit/{id}")]
        public async Task<IActionResult> Edit(long id, [FromBody] GameStats gameStats)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    gameStats.Id = id;
                    _context.Update(gameStats);
                    await _context.SaveChangesAsync();
                    return Ok();
                }
                catch (DbUpdateConcurrencyException)
                {
                    return BadRequest();
                }
            }
            else
            {
                return BadRequest();
            }
            
        }

        [HttpDelete]
        [Route("~/GameStats/Delete/{id}")]
        public async Task<IActionResult> Delete(long? id)
        {
            var item = await _context.GameStatsItems.FindAsync(id);
            if (item == null)
            {
                return NotFound();
            }
            _context.GameStatsItems.Remove(item);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
