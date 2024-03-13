using TaskOne.Models.Entities;

namespace TaskOne.Models.Dtos
{
    public class OrderDetailWithServiceDto
    {
        public int OrderDetailId { get; set; }
        public int OrderId { get; set; }
        public ServiceDto Service { get; set; }
        public int Quantity { get; set; }
    }
}
