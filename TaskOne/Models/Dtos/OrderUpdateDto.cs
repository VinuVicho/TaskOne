namespace TaskOne.Models.Dtos
{
    public class OrderUpdateDto
    {
        public int OrderId { get; set; }
        public int CustomerId { get; set; }
        public int ExecutorId { get; set; }
        public string Status { get; set; }
    }
}
