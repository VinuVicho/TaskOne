using System.ComponentModel.DataAnnotations;

namespace TaskOne.Models.Entities
{
    public class Customer
    {
        [Key]
        public int CustomerId{ get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public virtual List<Order>? Orders { get; set; }
    }
}
