using Microsoft.EntityFrameworkCore;
using TaskOne.Exceptions;
using TaskOne.Models.Dtos;
using TaskOne.Models.Entities;

namespace TaskOne.Models.Repositories.Impl
{
    public class CustomerRepo(AppDbContext context) : ICustomerRepo
    {
        public ICollection<Customer> GetCustomers()
        {
            return [.. context.Customers];
        }

        public Customer GetCustomer(int id)
        {
            return context.Customers.Find(id);
        }

        public bool DeleteCustomer(int id)
        {
            var rowsAffected = context.Customers.Where(c => c.CustomerId == id).ExecuteDelete();
            return rowsAffected != 0;
        }

        public Customer UpdateCustomer(Customer customer)
        {
            var toUpdate = context.Customers.FirstOrDefault(c => c.CustomerId == customer.CustomerId);
            if (toUpdate == null) 
                throw new NotFoundException("Cannot update customer with id: " + customer.CustomerId);
            context.Entry(toUpdate).CurrentValues.SetValues(customer);
            context.SaveChanges();
            return toUpdate;
        }

        public Customer SaveCustomer(Customer customer)
        {
            var result = context.Add(customer).Entity;
            context.SaveChanges();
            return result;
        }
    }
}
