using System.ComponentModel.DataAnnotations.Schema;

namespace TaskOne.Models.Dtos
{
    public class OrderDetailDto
    {
        public int OrderDetailId { get; set; }
        public int OrderId { get; set; }
        public int ServiceId { get; set; }
        public int Quantity { get; set; }
    }
}
