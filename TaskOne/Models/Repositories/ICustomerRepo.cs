using TaskOne.Models.Entities;

namespace TaskOne.Models.Repositories
{
    public interface ICustomerRepo
    {
        public ICollection<Customer> GetCustomers();
        public Customer GetCustomerById(int id);
        public bool DeleteCustomer(int id);
        public Customer UpdateCustomer(Customer customer);
        public Customer CreateCustomer(Customer customer);
    }
}
