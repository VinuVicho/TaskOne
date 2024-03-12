﻿using TaskOne.Models.Entities;

namespace TaskOne.Models.Repositories
{
    public interface ICustomerRepo
    {
        ICollection<Customer> GetCustomers();
        Customer GetCustomer(int id);
        bool DeleteCustomer(int id);
        Customer UpdateCustomer(Customer customer);
        Customer SaveCustomer(Customer customer);
    }
}
