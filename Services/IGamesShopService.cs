using REST_API_GAMES.Models;

namespace REST_API_GAMES.Services
{
    public interface IGamesShopService
    {
        // Developer Services
        Task<List<Developer>> GetDevelopersAsync(); // GET All Developers
        Task<Developer> GetDeveloperAsync(Guid id, bool includeGames = false); // GET Single Developer
        Task<Developer> AddDeveloperAsync(Developer developer); // POST New Developer
        Task<Developer> UpdateDeveloperAsync(Developer developer); // PUT Developer
        Task<(bool, string)> DeleteDeveloperAsync(Developer developer); // DELETE Developer
        // Publisher Services
        Task<List<Publisher>> GetPublishersAsync(); // GET All Publisher
        Task<Publisher> GetPublisherAsync(Guid id, bool includeGames = false); // GET Single Publisher
        Task<Publisher> AddPublisherAsync(Publisher publisher); // POST New Publisher
        Task<Publisher> UpdatePublisherAsync(Publisher publisher); // PUT Publisher
        Task<(bool, string)> DeletePublisherAsync(Publisher publisher); // DELETE Publisher

        // Game Services
        Task<List<Game>> GetGamesAsync(); // GET All Games
        Task<Game> GetGameAsync(Guid id); // Get Single Game
        Task<Game> AddGameAsync(Game game); // POST New Game
        Task<Game> UpdateGameAsync(Game game); // PUT Game
        Task<(bool, string)> DeleteGameAsync(Game game); // DELETE Game
    }
}