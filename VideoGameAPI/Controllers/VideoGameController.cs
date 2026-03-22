using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.InteropServices;
using static System.Net.WebRequestMethods;
using VideoGameAPI.Data;
using Microsoft.EntityFrameworkCore;
using VideoGameAPI.Models;

namespace VideoGameAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VideoGameController(VideoGameDbContext context) : ControllerBase
    {
        // primary constructor - vullen backing-variable
        private readonly VideoGameDbContext _context = context;

        //// variabele videoGames
        //static private List<VideoGame> videoGames = new List<VideoGame>
        //{
        //    new VideoGame
        //    {
        //        Id = 1,
        //        Title = "Spider-Man 2",
        //        Platform = "PS5",
        //        Developer = "Insomniac Games",
        //        Publisher = "Sony Interactive Entertainment"
        //    },
        //    new VideoGame
        //    {
        //        Id = 2,
        //        Title = "The Legend of Zelda: Breath of the Wild",
        //        Platform = "Nintendo Switch",
        //        Developer = "Nintendo EPO",
        //        Publisher = "Nintendo"
        //    },
        //    new VideoGame
        //    {
        //        Id = 3,
        //        Title = "Cyberpunk 2077",
        //        Platform = "PC",
        //        Developer = "CD Projekt Red",
        //        Publisher = "CD Projekt"
        //    }
        //};

        [HttpGet]
        public async Task<ActionResult<List<VideoGame>>> GetVideoGames()
        {
            return Ok(await _context.VideoGames
                .Include(g => g.VideoGameDetails)
                .Include(g => g.Publisher)
                .Include(g => g.Developer)
                .Include(g => g.Genre)
                .ToListAsync());
        }

        [HttpGet("{id}")]
        // [Route("{id}")]
        public async Task<ActionResult<List<VideoGame>>> GetVideoGamesById(int id)
        {
            var game = await _context.VideoGames.FindAsync(id);
            if (game is null)
            {
                return NotFound();
            }
            return Ok(game);
        }

        [HttpPost]
        public async Task<ActionResult<VideoGame>> AddVideoGame(VideoGame newGame)
        {
            if (newGame == null) return BadRequest();

            _context.VideoGames.Add(newGame);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetVideoGamesById), new { id = newGame.Id }, newGame);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateVideoGame(int id, VideoGame updateGame)
        {

            var game = await _context.VideoGames.FindAsync(id);
            if (game is null) return NotFound();

            game.Title = updateGame.Title;
            game.Platform = updateGame.Platform;
            game.Developer = updateGame.Developer;
            game.Publisher = updateGame.Publisher;

            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult>DeleteVideoGame(int id)
        {

            var game = await _context.VideoGames.FindAsync(id);
            if (game is null) return NotFound();

            _context.VideoGames.Remove(game);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
