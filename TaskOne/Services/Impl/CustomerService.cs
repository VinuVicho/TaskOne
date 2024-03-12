using AutoMapper;
using TaskOne.Exceptions;
using TaskOne.Models.Dtos;
using TaskOne.Models.Entities;
using TaskOne.Models.Repositories;

namespace TaskOne.Services.Impl
{
    public class CustomerService(ICustomerRepo customerRepo, IMapper mapper) : ICustomerService
    {
        public ICollection<CustomerDto> GetCustomers()
        {
            return customerRepo.GetCustomers().Select(mapper.Map<CustomerDto>).ToList();
        }

        public CustomerDto CreateCustomer(CustomerDto customerDto)
        {
            var resultCustomer = customerRepo.CreateCustomer(mapper.Map<Customer>(customerDto));
            return mapper.Map<CustomerDto>(resultCustomer);
        }

        public CustomerDto UpdateCustomer(CustomerDto customerDto)
        {
            var resultCustomer = customerRepo.UpdateCustomer(mapper.Map<Customer>(customerDto));
            return mapper.Map<CustomerDto>(resultCustomer);
        }

        public void DeleteCustomer(int customerId)
        {
            if (!customerRepo.DeleteCustomer(customerId))
            {
                throw new NotFoundException("Customer cannot be deleted with id: " + customerId);
            }
        }

        public CustomerDto GetCustomerById(int customerId)
        {
            var customer = customerRepo.GetCustomerById(customerId);
            return customer == null
                ? throw new NotFoundException("Customer not found with id: " + customerId)
                : mapper.Map<CustomerDto>(customer);
        }
    }
}
