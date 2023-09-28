using System.ComponentModel.DataAnnotations;

namespace REST_API_GAMES.Models
{
    public class Developer
    {
        [Key]
        public Guid Id { get; set; }
        public string? Name { get; set; }
        // One-to-many relationship with books
        public List<Game>? Games { get; set; }
    }
}
