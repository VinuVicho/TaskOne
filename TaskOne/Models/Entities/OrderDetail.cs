using System.ComponentModel.DataAnnotations;

namespace TaskOne.Models.Entities
{
    public class OrderDetail
    {
        [Key]
        public int OrderDetailId { get; set; }
        public int OrderId { get; set; }
        public int ServiceId { get; set; }
        public int Quantity { get; set; }
        public virtual Service Service { get; set; }
        public virtual Order Order { get; set; }
    }
}
