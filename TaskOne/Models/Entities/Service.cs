using System.ComponentModel.DataAnnotations;

namespace TaskOne.Models.Entities
{
    public class Service
    {
        [Key]
        public int ServiceId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
    }
}
