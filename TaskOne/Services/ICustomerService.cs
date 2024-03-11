using TaskOne.Models.Dtos;

namespace TaskOne.Services
{
    public interface ICustomerService
    {
        public ICollection<CustomerDto> GetCustomers();
        public CustomerDto CreateCustomer(CustomerDto customerDto);
        public CustomerDto UpdateCustomer(CustomerDto customerDto);
        public void DeleteCustomer(int customerId);
        public CustomerDto GetCustomerById(int customerId);
    }
}
