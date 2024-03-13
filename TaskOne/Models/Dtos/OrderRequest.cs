namespace TaskOne.Models.Dtos
{
    public class OrderRequest
    {
        public int CustomerId { get; set; }
        public int ExecutorId { get; set; }
        public int ServiceId { get; set; }
        public int Quantity { get; set; }
    }
}
