using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;

namespace REST_API_GAMES.Models
{
    [Table("OrderItems", Schema = "OrderItems")]
    public class OrderItem
    {

        [Key]
        public Guid Id { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public Guid GameId { get; set; }
        public Game Game { get; set; }
        public Guid OrderId { get; set; }
        public Order Order { get; set; }



    }
}
