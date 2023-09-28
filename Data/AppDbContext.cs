using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using REST_API_GAMES.Models;

namespace REST_API_GAMES.Data
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
        }

        public DbSet<Developer> Developer { get; set; }
        public DbSet<Game> Games { get; set; }
        public DbSet<Publisher> Publisher { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {

            // Define relationship between books and authors
            builder.Entity<Game>()
                .HasOne(x => x.Developer)      
                .WithMany(x => x.Games);
            builder.Entity<Game>()
                .HasOne(x => x.Publisher)
                    .WithMany(x => x.Games);

            // Seed database with authors and books for demo
            new DbInitializer(builder).Seed();
        }
    }


}

