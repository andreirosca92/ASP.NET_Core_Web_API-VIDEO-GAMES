using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;

namespace REST_API_GAMES.Models
{
    [Table("Games", Schema ="Games")]
    public class Game
    {

        public Game(){
             this.GameDevelopers = new HashSet<GameDeveloper>();
             this.GamesOrders = new HashSet<OrderItem>();
             this.Id = System.Guid.NewGuid();
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public string? Name { get; set; }
       
        public string? Description { get; set; }
        public Genre? Genre { get; set; }
        public Platform? Platform { get; set; }
        public Conditions? Conditions { get; set; }
        public double? Rating { get; set; }
       public DateTime Time { get; set; } = DateTime.Now;


        // One-to-One relation with Developer
        public Inventory Inventory { get; set; }

        // Many-to-Many with Developer
        public ICollection<GameDeveloper> GameDevelopers { get; set; }

        // One-to-many relation with Publisher
        public Guid? PublisherId { get; set; }
        public Publisher? Publisher { get; set; }

        // Many-to-many relation with Order
        public ICollection<OrderItem> GamesOrders { get; set; }
    }
}
