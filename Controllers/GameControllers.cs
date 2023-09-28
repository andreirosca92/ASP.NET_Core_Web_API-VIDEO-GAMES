using Microsoft.AspNetCore.Mvc;
using REST_API_GAMES.Models;
using REST_API_GAMES.Services;

namespace REST_API_GAMES.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GameController : ControllerBase
    {
        private readonly IGamesShopService _gamesShopService;

        public GameController(IGamesShopService gamesShopService)
        {
            _gamesShopService = gamesShopService;
        }

        [HttpGet]
        public async Task<IActionResult> GetGames()
        {
            var games = await _gamesShopService.GetGamesAsync();
            if (games == null)
            {
                return StatusCode(StatusCodes.Status204NoContent, "No games in database.");
            }

            return StatusCode(StatusCodes.Status200OK, games);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetGames(Guid id)
        {
            Game game = await _gamesShopService.GetGameAsync(id);

            if (game == null)
            {
                return StatusCode(StatusCodes.Status204NoContent, $"No Game found for id: {id}");
            }

            return StatusCode(StatusCodes.Status200OK, game);
        }

        [HttpPost]
        public async Task<ActionResult<Game>> AddGame(Game game)
        {
            var dbGame = await _gamesShopService.AddGameAsync(game);

            if (dbGame == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"{game.Name} could not be added.");
            }

            return CreatedAtAction("GetGame", new { id = game.Id }, game);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateGame(Guid id, Game game)
        {
            if (id != game.Id)
            {
                return BadRequest();
            }

            Game dbGame = await _gamesShopService.UpdateGameAsync(game);

            if (dbGame == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"{game.Name} could not be updated");
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGame(Guid id)
        {
            var game = await _gamesShopService.GetGameAsync(id);
            (bool status, string message) = await _gamesShopService.DeleteGameAsync(game);

            if (status == false)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, message);
            }

            return StatusCode(StatusCodes.Status200OK, game);
        }
    }
}