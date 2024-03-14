namespace TaskOne.Models.Dtos
{
    public class OrderRequest
    {
        public int CustomerId { get; set; }
        public int ExecutorId { get; set; }
        public List<OrderDetailsForOrderRequest> orderDetails { get; set; }
    }
}
