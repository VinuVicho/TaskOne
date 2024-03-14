namespace TaskOne.Models.Dtos
{
    public class OrderDetailRequest
    {
        public int OrderId { get; set; }
        public List<OrderDetailsForOrderRequest> OrderDetails { get; set; }
    }
}
