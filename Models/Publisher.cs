using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace REST_API_GAMES.Models
{
    [Table("Publisher", Schema ="Publisher")]
    public class Publisher
    {
        public Publisher(){
            this.Id = System.Guid.NewGuid();
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public string? Name { get; set; }
        // One-to-many relationship with games
        public List<Game>? Games { get; set; }
    }
}
