﻿using AutoMapper;
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
            var resultCustomer = customerRepo.SaveCustomer(mapper.Map<Customer>(customerDto));
            return mapper.Map<CustomerDto>(resultCustomer);
        }

        public CustomerDto UpdateCustomer(CustomerDto customerDto)
        {
            var resultCustomer = customerRepo.UpdateCustomer(mapper.Map<Customer>(customerDto));
            return mapper.Map<CustomerDto>(resultCustomer);
        }

        public void DeleteCustomer(int customerId)
        {
            customerRepo.DeleteCustomer(customerId);
        }

        public CustomerDto GetCustomerById(int customerId)
        {
            var customer = customerRepo.GetCustomer(customerId);
            if (customer == null)
                throw new NotFoundException("User not found with id: " + customerId);
            return mapper.Map<CustomerDto>(customer);
        }
    }
}
