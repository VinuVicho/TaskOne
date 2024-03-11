using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TaskOne.Models.Entities
{
    public class OrderDetail
    {
        [Key]
        public int OrderDetailId { get; set; }
        public int? OrderId { get; set; }
        public int? ServiceId { get; set; }
        public int Quantity { get; set; }

    }
}
