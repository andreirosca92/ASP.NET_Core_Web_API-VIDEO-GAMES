using System.ComponentModel.DataAnnotations;

namespace REST_API_GAMES.Models
{
    public class Game
    {
        [Key]
        public Guid Id { get; set; }
        public string? Name { get; set; }
       
        public string? Description { get; set; }
        public Genre? Genre { get; set; }
        public Platform? Platform { get; set; }
        public double? Rating { get; set; }
       public DateTime Time { get; set; } = DateTime.Now;


        // One-to-many relation with Developer
        public Guid? DeveloperId { get; set; }
        public Developer? Developer { get; set; }

        // One-to-many relation with Publisher
        public Guid? PublisherId { get; set; }
        public Publisher? Publisher { get; set; }
    }
}
