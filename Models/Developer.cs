using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace REST_API_GAMES.Models
{
    [Table("Developer", Schema ="Developer")]
    public class Developer
    {
        public Developer(){
             this.GameDevelopers = new HashSet<GameDeveloper>();
             this.Id = System.Guid.NewGuid();
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public string? Name { get; set; }
        // Many-to-Many with Game
        public ICollection<GameDeveloper> GameDevelopers { get; set; }
    }
}
