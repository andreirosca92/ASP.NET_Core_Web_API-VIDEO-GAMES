using Microsoft.EntityFrameworkCore;
using REST_API_GAMES.Data;
using REST_API_GAMES.Models;

namespace REST_API_GAMES.Services
{
    public class VideoGamesService : IGamesShopService
    {
        private readonly AppDbContext _db;

        public VideoGamesService(AppDbContext db)
        {
            _db = db;
        }

        #region Developer

        public async Task<List<Developer>> GetDevelopersAsync()
        {
            try
            {
                return await _db.Developer.ToListAsync();
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<Developer> GetDeveloperAsync(Guid id, bool includeGames)
        {
            try
            {
                if (includeGames) // developers should be included
                {
                    return await _db.Developer.Include(b => b.GameDevelopers)
                        .FirstOrDefaultAsync(i => i.Id == id);
                }

                // developers should be excluded
                return await _db.Developer.FindAsync(id);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<Developer> AddDeveloperAsync(Developer developer)
        {
            try
            {
                await _db.Developer.AddAsync(developer);
                await _db.SaveChangesAsync();
                return await _db.Developer.FindAsync(developer.Id); // Auto ID from DB
            }
            catch (Exception ex)
            {
                return null; // An error occured
            }
        }

        public async Task<Developer> UpdateDeveloperAsync(Developer developer)
        {
            try
            {
                _db.Entry(developer).State = EntityState.Modified;
                await _db.SaveChangesAsync();

                return developer;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<(bool, string)> DeleteDeveloperAsync(Developer developer)
        {
            try
            {
                var dbAuthor = await _db.Developer.FindAsync(developer.Id);

                if (dbAuthor == null)
                {
                    return (false, "Developer could not be found");
                }

                _db.Developer.Remove(developer);
                await _db.SaveChangesAsync();

                return (true, "Developer got deleted.");
            }
            catch (Exception ex)
            {
                return (false, $"An error occured. Error Message: {ex.Message}");
            }
        }

        #endregion Developer
         #region Publisher

        public async Task<List<Publisher>> GetPublishersAsync()
        {
            try
            {
                return await _db.Publisher.ToListAsync();
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<Publisher> GetPublisherAsync(Guid id, bool includeGames)
        {
            try
            {
                if (includeGames) // developers should be included
                {
                    return await _db.Publisher.Include(b => b.Games)
                        .FirstOrDefaultAsync(i => i.Id == id);
                }

                // developers should be excluded
                return await _db.Publisher.FindAsync(id);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<Publisher> AddPublisherAsync(Publisher publisher)
        {
            try
            {
                await _db.Publisher.AddAsync(publisher);
                await _db.SaveChangesAsync();
                return await _db.Publisher.FindAsync(publisher.Id); // Auto ID from DB
            }
            catch (Exception ex)
            {
                return null; // An error occured
            }
        }

        public async Task<Publisher> UpdatePublisherAsync(Publisher publisher)
        {
            try
            {
                _db.Entry(publisher).State = EntityState.Modified;
                await _db.SaveChangesAsync();

                return publisher;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<(bool, string)> DeletePublisherAsync(Publisher publisher)
        {
            try
            {
                var dbPublisher = await _db.Publisher.FindAsync(publisher.Id);

                if (dbPublisher == null)
                {
                    return (false, "Publisher could not be found");
                }

                _db.Publisher.Remove(publisher);
                await _db.SaveChangesAsync();

                return (true, "Publisher got deleted.");
            }
            catch (Exception ex)
            {
                return (false, $"An error occured. Error Message: {ex.Message}");
            }
        }

        #endregion Publisher

        #region Games

        public async Task<List<Game>> GetGamesAsync()
        {
            try
            {
                return await _db.Games.ToListAsync();
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<Game> GetGameAsync(Guid id)
        {
            try
            {
                return await _db.Games.FindAsync(id);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<Game> AddGameAsync(Game game)
        {
            try
            {
                await _db.Games.AddAsync(game);
                await _db.SaveChangesAsync();
                return await _db.Games.FindAsync(game.Id); // Auto ID from DB
            }
            catch (Exception ex)
            {
                return null; // An error occured
            }
        }

        public async Task<Game> UpdateGameAsync(Game game)
        {
            try
            {
                _db.Entry(game).State = EntityState.Modified;
                await _db.SaveChangesAsync();

                return game;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<(bool, string)> DeleteGameAsync(Game game)
        {
            try
            {
                var dbgames = await _db.Games.FindAsync(game.Id);

                if (dbgames == null)
                {
                    return (false, "Game could not be found.");
                }

                _db.Games.Remove(game);
                await _db.SaveChangesAsync();

                return (true, "Game got deleted.");
            }
            catch (Exception ex)
            {
                return (false, $"An error occured. Error Message: {ex.Message}");
            }
        }

        #endregion Games
    }
}