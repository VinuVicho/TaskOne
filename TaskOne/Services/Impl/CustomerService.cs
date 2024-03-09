using TaskOne.Models.Entities;
using TaskOne.Models.Repositories;

namespace TaskOne.Services.Impl
{
    public class CustomerService(ICustomerRepo customerRepo) : ICustomerService
    {
        public ICollection<Customer> GetCustomers()
        {
            return customerRepo.getCustomers();
        }
    }
}
