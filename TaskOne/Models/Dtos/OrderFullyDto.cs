namespace TaskOne.Models.Dtos
{
    public class OrderFullyDto
    {
        public int OrderId { get; set; }
        public int CustomerId { get; set; }
        public int ExecutorId { get; set; }
        public string Status { get; set; }
        public decimal TotalAmount { get; set; }
        public DateTime OrderDate { get; set; }
        public List<OrderDetailDto> OrderDetails { get; set; }
    }
}
