namespace TaskOne.Models.Dtos
{
    public class ExecutorUpdateRequest
    {
        public int ExecutorId { get; set; }
        public required string Name { get; set; }
        public required string Email { get; set; }
        public required string Password { get; set; }
    }
}
