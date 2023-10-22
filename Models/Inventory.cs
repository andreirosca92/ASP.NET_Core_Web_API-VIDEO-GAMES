using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace REST_API_GAMES.Models
{
    [Table("Inventories", Schema = "Inventories")]
    public class Inventory
    {
        [Key, ForeignKey("Game")]
        public Guid Id { get; set; }

        public string StockLevelNew {  get; set; }
        public string StockLevelUsed {  get; set; }
        public Game Game { get; set; }

    }
}
