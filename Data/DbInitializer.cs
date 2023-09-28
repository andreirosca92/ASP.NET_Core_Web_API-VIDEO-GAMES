using Microsoft.EntityFrameworkCore;
using REST_API_GAMES.Models;
using System;

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
                    Id = new Guid("d1456296-16ea-4e11-ab71-a2d59805000d"),
                    Name = "Infinity Ward",
                  
                });
                a.HasData(new Developer
                {
                    Id = new Guid("ccb4bb29-1c2c-4ba1-9605-d8349ae4abd3"),
                    Name = "4A Games",
                   
                });
            });

            _builder.Entity<Game>(b =>
            {
                b.HasData(new Game
                {
                    Id = new  Guid("ccb4bb29-1c2c-4ba1-9605-d8349ae4abd3"),
                    Name = "Call of Duty: Modern Warfare 3",
                    Description = "Modern Warfare 3 is a first-person shooter video game much like its predecessors. Modern Warfare 3 for Microsoft Windows has dedicated server support.",
                    Genre = Genre.First_Person_shooter,
                    Platform=Platform.WINDOWS,
                    Rating =float.Parse("10"),
                  
                    DeveloperId = new  Guid("d1456296-16ea-4e11-ab71-a2d59805000d"),
                    PublisherId= new Guid("156b737b-1f6c-4977-bebd-c4a01307b781"),
                });
                b.HasData(new Game
                {
                    Id = new  Guid("79279c60-511f-45e5-99b5-e974ba347fca"),
                    Name = "Metro 2033",
                    Description = "Metro 2033",
                    Genre = Genre.First_Person_shooter,
                    Platform=Platform.PS5,
               
                    Rating = float.Parse("9"),
                   
                    DeveloperId = new  Guid("ccb4bb29-1c2c-4ba1-9605-d8349ae4abd3"),
                    PublisherId= new Guid("2cb2beed-c229-4c9f-9a08-df385ec0d548")
                });
                
            });
            _builder.Entity<Publisher>(c =>
            {
                c.HasData(new Publisher
                {

                    Id = new Guid("156b737b-1f6c-4977-bebd-c4a01307b781"),
                    Name="Activision"
                }) ;
                c.HasData(new Publisher
                {

                    Id =new Guid("2cb2beed-c229-4c9f-9a08-df385ec0d548"),
                    Name = "THQ"
                });
            });
        }
    }
}
