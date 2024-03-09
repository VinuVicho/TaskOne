using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TaskOne.Models.Entities
{
    public class OrderDetail
    {

        [Key]
        public int OrderDetailId { get; set; }
        [ForeignKey("Order")]
        public int OrderId { get; set; }
        [ForeignKey("Service")]
        public int ServiceId { get; set; }
        public int Quantity { get; set; }

    }
}
