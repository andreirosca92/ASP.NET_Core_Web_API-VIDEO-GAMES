using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;

namespace REST_API_GAMES.Models
{
    [Table("GameDeveloper", Schema = "GameDeveloper")]
    public class GameDeveloper
    {

        
        public Guid GameId { get; set; }
        public Game Game { get; set; }
        public Guid DeveloperId { get; set; }
        public Developer Developer { get; set; }



    }
}
