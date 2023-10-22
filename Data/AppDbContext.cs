using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.EntityFrameworkCore.ValueGeneration;
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
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<GameDeveloper> GameDevelopers { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {

            // Define relationship between games and developers
            builder.Entity<Game>()
                .Property(e=> e.Genre)
                .HasConversion(v => v.ToString(),
                                v => (Genre)Enum.Parse(typeof(Genre), v));
            builder.Entity<Game>()
                .Property(e=> e.Platform)
                .HasConversion(v => v.ToString(),
                                v => (Platform)Enum.Parse(typeof(Platform), v));
            builder.Entity<Game>()
                .Property(e => e.Conditions)
                .HasConversion(v => v.ToString(),
                                v => (Conditions)Enum.Parse(typeof(Conditions), v));
            builder.Entity<Game>()
                .Property(g => g.Name)
                .HasColumnName("Name")
                .HasColumnOrder(2)
                .IsRequired();
            builder.Entity<Game>()
                .Property(g=> g.Description)
                .HasColumnName("Description")
                .HasColumnOrder(3)
                .IsRequired();
            builder.Entity<Game>()
                .Property(g => g.Id)
                .HasValueGenerator<GuidValueGenerator>();
            builder.Entity<Order>()
                .Property(o => o.Id)
                .HasValueGenerator<GuidValueGenerator>();
            builder.Entity<Publisher>()
                .Property(p=>p.Id)
                .HasValueGenerator<GuidValueGenerator>();
            builder.Entity<Developer>()
                .Property(d=> d.Id)
                .HasValueGenerator<GuidValueGenerator>();
            builder.Entity<OrderItem>()
                .Property(oi => oi.Id)
                .HasValueGenerator<GuidValueGenerator>();



            builder.Entity<Game>()
                .HasOne(g => g.Inventory)
                .WithOne(i => i.Game)
                .HasForeignKey<Inventory>(i => i.Id);

            builder.Entity<Game>()
                .HasOne(x => x.Publisher)
                    .WithMany(x => x.Games);

            builder.Entity<OrderItem>()
                 .HasKey(oi => new { oi.OrderId, oi.GameId });

            builder.Entity<OrderItem>()
                .HasOne(oi => oi.Order)
                .WithMany(o => o.GamesOrders)
                .HasForeignKey(oi => oi.OrderId);
            builder.Entity<OrderItem>()
                .HasOne(oi => oi.Game)
                .WithMany(g => g.GamesOrders)
                .HasForeignKey(oi => oi.GameId);

            builder.Entity<GameDeveloper>()
               .HasKey(gd => new { gd.GameId, gd.DeveloperId});

            builder.Entity<GameDeveloper>()
                .HasOne(gd => gd.Developer)
                .WithMany(d => d.GameDevelopers)
                .HasForeignKey(gd => gd.DeveloperId);
            builder.Entity<GameDeveloper>()
                .HasOne(gd => gd.Game)
                .WithMany(g => g.GameDevelopers)
                .HasForeignKey(gd => gd.GameId);


            // Seed database with games and developers for demo
            new DbInitializer(builder).Seed();
            //base.OnModelCreating(builder);
        }
    }


}

