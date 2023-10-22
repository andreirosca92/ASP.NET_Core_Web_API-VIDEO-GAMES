using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;

namespace REST_API_GAMES.Models
{
    [Table("Orders", Schema = "Orders")]
    public class Order
    {

        public Order(){
             this.GamesOrders = new HashSet<OrderItem>();
        }
        [Key]
        public Guid Id { get; set; }
     
        public DateTime OrderDate { get; set; }

        public double SubTotal { get; set; }
        public double Total { get; set; }


        // Many-to-Many with Game
        public ICollection<OrderItem> GamesOrders { get; set; }



    }
}
