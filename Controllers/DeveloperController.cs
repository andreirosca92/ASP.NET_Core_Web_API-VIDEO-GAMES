using Microsoft.AspNetCore.Mvc;
using REST_API_GAMES.Models;
using REST_API_GAMES.Services;

namespace REST_API_GAMES.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthorController : ControllerBase
    {
        private readonly IGamesShopService _gamesShopService;

        public AuthorController(IGamesShopService gamesShopService)
        {
            _gamesShopService= gamesShopService;
        }

        [HttpGet]
        public async Task<IActionResult> GetDevelopers()
        {
            var developers = await _gamesShopService.GetDevelopersAsync();

            if (developers == null)
            {
                return StatusCode(StatusCodes.Status204NoContent, "No developers in database");
            }

            return StatusCode(StatusCodes.Status200OK, developers);
        }

        [HttpGet("id")]
        public async Task<IActionResult> GetDeveloper(Guid id, bool includeGames = false)
        {
            Developer developer = await _gamesShopService.GetDeveloperAsync(id,includeGames );

            if (developer == null)
            {
                return StatusCode(StatusCodes.Status204NoContent, $"No Developer found for id: {id}");
            }

            return StatusCode(StatusCodes.Status200OK, developer);
        }

        [HttpPost]
        public async Task<ActionResult<Developer>> AddDeveloper(Developer developer)
        {
            var dbDeveloper = await _gamesShopService.AddDeveloperAsync(developer);

            if (dbDeveloper == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"{developer.Name} could not be added.");
            }

            return CreatedAtAction("GetDeveloper", new { id = developer.Id },developer);
        }

        [HttpPut("id")]
        public async Task<IActionResult> UpdateDeveloper(Guid id, Developer developer)
        {
            if (id != developer.Id)
            {
                return BadRequest();
            }

            Developer dbDeveloper = await _gamesShopService.UpdateDeveloperAsync(developer);

            if (dbDeveloper == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"{developer.Name} could not be updated");
            }

            return NoContent();
        }

        [HttpDelete("id")]
        public async Task<IActionResult> DeleteDeveloper(Guid id)
        {
            var developer = await _gamesShopService.GetDeveloperAsync(id, false);
            (bool status, string message) = await _gamesShopService.DeleteDeveloperAsync(developer);

            if (status == false)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, message);
            }

            return StatusCode(StatusCodes.Status200OK, developer);
        }
    }
}