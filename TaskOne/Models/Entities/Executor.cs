using System.ComponentModel.DataAnnotations;

namespace TaskOne.Models.Entities
{
    public class Executor
    {
        [Key]
        public int ExecutorId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
    }
}
