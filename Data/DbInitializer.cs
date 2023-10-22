using Microsoft.EntityFrameworkCore;
using REST_API_GAMES.Models;
using System;
using System.Diagnostics;

namespace REST_API_GAMES.Data
{
    public class DbInitializer
    {
        private readonly ModelBuilder _builder;

        public DbInitializer(ModelBuilder builder)
        {
            _builder = builder;
        }
        public void Seed()
        {
            _builder.Entity<Developer>(a =>
            {
                a.HasData(new Developer
                {
                    
                    Name = "Infinity Ward",
                    

                });
                a.HasData(new Developer
                {
                    
                    Name = "4A Games",
                    

                });
            });

            _builder.Entity<Game>(b =>
            {
                b.HasData(new Game
                {
                  
                    Name = "Call of Duty: Modern Warfare 3",
                    Description = "Modern Warfare 3 is a first-person shooter video game much like its predecessors. Modern Warfare 3 for Microsoft Windows has dedicated server support.",
                    Genre = Genre.First_Person_shooter,
                    Platform=Platform.WINDOWS,
                    Conditions = Conditions.NEW,
                    Rating =float.Parse("10"),
                  
                    
                });
                b.HasData(new Game
                {
                    
                    Name = "Metro 2033",
                    Description = "Metro 2033",
                    Genre = Genre.First_Person_shooter,
                    Platform=Platform.PS5,
                    Conditions = Conditions.NEW,
                    Rating = float.Parse("9"),
                   
                });
                
            });
            _builder.Entity<Publisher>(c =>
            {
                c.HasData(new Publisher
                {

                    Name="Activision"
                }) ;
                c.HasData(new Publisher
                {

                    Name = "THQ"
                });
            });
        }
    }
}
