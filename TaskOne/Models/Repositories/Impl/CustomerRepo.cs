using TaskOne.Data;
using TaskOne.Models.Entities;

namespace TaskOne.Models.Repositories.Impl
{
    public class CustomerRepo(AppDbContext context) : ICustomerRepo
    {
        public ICollection<Customer> getCustomers()
        {
            return [.. context.Customers];
        }
    }
}
