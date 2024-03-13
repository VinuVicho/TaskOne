namespace TaskOne.Models.Dtos
{
    public class NewOrderDetailsRequest
    {
        public int OrderId { get; set; }
        public int ServiceId { get; set; }
        public int Quantity { get; set; }
    }
}
