using TaskOne.Models.Entities;

namespace TaskOne.Services
{
    public interface ICustomerService
    {
        public ICollection<Customer> GetCustomers();
    }
}
