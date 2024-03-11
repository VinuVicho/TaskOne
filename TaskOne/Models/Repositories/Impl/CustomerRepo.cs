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

        public void DeleteCustomer(int id)
        {
            var toDelete = context.Customers.Find(id);
            if (toDelete != null) 
                context.Customers.Remove(toDelete);
        }

        public Customer UpdateCustomer(Customer customer)
        {
            var result = context.Update(customer).Entity;
            context.SaveChanges();
            return result;
        }

        public Customer SaveCustomer(Customer customer)
        {
            var result = context.Add(customer).Entity;
            context.SaveChanges();
            return result;
        }
    }
}
