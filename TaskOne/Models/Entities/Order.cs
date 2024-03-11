using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TaskOne.Models.Entities
{
    public class Order
    {
        [Key]
        public int OrderId { get; set; }
        public int CustomerId { get; set; }
        public int ExecutorId { get; set; }
        public string Status { get; set; }
        public decimal TotalAmount { get; set; }
        public DateTime OrderDate { get; set; }
    }
}
